using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NorthWind.Application.Dtos.Customer;
using NorthWind.Web.Models.Response;
using NorthWind.Web.WebService.Interface;


namespace NorthWind.Web.WebService.Service
{
    public class CustomerApiService : Controller, ICustomerApiService
    {

        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<CustomerApiService> logger;
        private readonly string urlBase;

        public CustomerApiService(IHttpClientFactory httpClientFactory, IConfiguration configuration, ILogger<CustomerApiService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.urlBase = this.configuration["ApiEndpoint:urlBase"];
        }

        public async Task<CustomerDetailResponse> Edit(string id)
        {
            CustomerDetailResponse customerDetail = new CustomerDetailResponse();


            using (var httpClient = this.httpClientFactory.CreateClient())
            {

                var response = await httpClient.GetAsync($"{this.urlBase}/GetCustomerById?id={id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        customerDetail = JsonConvert.DeserializeObject<CustomerDetailResponse>(apiResponse);

                    }
            }

            return customerDetail;
        }

        public async Task<CustomerDetailResponse> GetCustomer(string id)
        {

            CustomerDetailResponse customerDetail = new CustomerDetailResponse();

            try
            {

                using (var httpClient = this.httpClientFactory.CreateClient())
                {

                    using (var response = await httpClient.GetAsync($"{this.urlBase}/GetCustomerById?id={id}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();

                            customerDetail = JsonConvert.DeserializeObject<CustomerDetailResponse>(apiResponse);

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                customerDetail.message = "Error conectandose al Api.";
                customerDetail.success = false;
                this.logger.LogError(customerDetail.message, ex.ToString());
            }

            return customerDetail;
        }

        public async Task<CustomerListResponse> GetCustomers()
        {

            CustomerListResponse customerList = new CustomerListResponse();

            try
            {

                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = await httpClient.GetAsync($"{this.urlBase}/GetCustomers"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();

                            customerList = JsonConvert.DeserializeObject<CustomerListResponse>(apiResponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                customerList.message = "Error conectandose al Api.";
                customerList.success = false;
                this.logger.LogError(customerList.message, ex.ToString());
            }

            return customerList;
        }

        public async Task<BaseResponse> Save(CustomerDtoAdd customerDtoAdd)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {

                    customerDtoAdd.ChangeDate = DateTime.Now;
                    customerDtoAdd.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(customerDtoAdd), System.Text.Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync($"{this.urlBase}/SaveCustomer", content);
                    
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                    if (response.IsSuccessStatusCode)
                    {
                        return baseResponse;
                    }                                         
                }

            }
            catch(Exception ex)
            {
                baseResponse.message = "Error conectandose al Api.";
                baseResponse.success = false;
                this.logger.LogError(baseResponse.message, ex.ToString());
            }

            return baseResponse;
        }

        public async Task<BaseResponse> Update(CustomerDtoUpdate customerDtoUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {

                customerDtoUpdate.ChangeDate = DateTime.Now;
                customerDtoUpdate.ChangeUser = 1;

                using (var httpClient = this.httpClientFactory.CreateClient())
                {

                    StringContent content = new StringContent(JsonConvert.SerializeObject(customerDtoUpdate), System.Text.Encoding.UTF8, "application/json");


                    var response = await httpClient.PostAsync($"{this.urlBase}/UpdateCustomer", content);


                    string apiResponse = await response.Content.ReadAsStringAsync();


                    baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                    if (response.IsSuccessStatusCode)
                    {
                        return baseResponse;
                    }

                }

            }
            catch(Exception ex)
            {
                baseResponse.message = "Error conectandose al Api.";
                baseResponse.success = false;
                this.logger.LogError(baseResponse.message, ex.ToString());
            }

            return baseResponse;
        }
    }
}
