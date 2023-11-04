
using System;
using Microsoft.Extensions.Logging;
using NorthWind.Application.Contracts;
using NorthWind.Application.Core;
using NorthWind.Infrastructure.Interfaces;

namespace NorthWind.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoriesRepositry categoriesRepositry;
        private readonly ILogger<CategoryService> logger;

        public CategoryService(ICategoriesRepositry categoriesRepositry,
                               ILogger<CategoryService> logger)
        {
            this.categoriesRepositry = categoriesRepositry;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.categoriesRepositry.GetEntities();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error obteniendo las categorias.";
                this.logger.LogError($"{result.Message}", ex.ToString());

            }

            return result;
        }

        public ServiceResult GetById(int Id)
        {

            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.categoriesRepositry.GetEntity(Id);

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo el cliente.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }



        public ServiceResult Save(AddCategory dtoAdd)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Categories category = new Categories()
                {
                    CategoryID = dtoAdd.CategoryID,

                    CategoryName = dtoAdd.CategoryName,

                    Description = dtoAdd.Description,

                    Picture = dtoAdd.Picture
                };

                this.categoriesRepositry.Save(category);

                result.Message = "Categoria guardada satisfactoriamente";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error guardando la categoria.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Update(UpdateCategory dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Categories categorie = this.categoriesRepositry.GetEntity(dtoUpdate.CategoryID);
                if (categorie != null)
                {
                    Categories categories = new Categories()
                    {
                        CategoryID=dtoUpdate.CategoryID,
                        Description = dtoUpdate.Description,
                        CategoryName=dtoUpdate.CategoryName,   
                        Picture = dtoUpdate.Picture,
                    };
                    this.categoriesRepositry.Update(categories);
                    result.Message = "Categoria actualizada satisfactoriamente";
                }

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error actualizando la categoria.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Remove(DeleteCategory dtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                this.categoriesRepositry.DeleteCategory(dtoRemove.CategoryID);

                result.Message = "Cliente eliminado satisfactoriamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error removiendo el cliente.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
    }
}