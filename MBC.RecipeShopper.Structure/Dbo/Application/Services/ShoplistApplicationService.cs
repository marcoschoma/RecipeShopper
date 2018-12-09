using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBC.RecipeShopper.Dbo.Domain.Commands.Handlers;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Shoplist;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.Shoplist;
using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Repositories;
using MBC.RecipeShopper.Dbo.Domain.Services;
using MBC.RecipeShopper.Shared.Infra.Data.Transactions;
using MBC.RecipeShopper.Shared.Domain.Commands;

using MBC.RecipeShopper.Shared.Infra;
using MBC.RecipeShopper.Dbo;
using MBC.RecipeShopper.Shared.Application;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.ShoplistIngredient;
using System;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.ShoplistIngredient;

namespace MBC.RecipeShopper.Dbo.Application.Services
{


    public class ShoplistApplicationService : ApplicationService, IShoplistApplicationService
    {

        private IShoplistRepository _repository;
        private IRecipeRepository _recipeRepository;

        private ShoplistCommandHandler _handler;

        public ShoplistApplicationService(IUnitOfWork uow, IShoplistRepository repository, ShoplistCommandHandler handler,
            IRecipeRepository recipeRepository) :
                base(uow)
        {
            this._handler = handler;
            this._repository = repository;
            this._recipeRepository = recipeRepository;
        }

        public virtual async Task<NotificationResult> InsertAsync(InsertShoplistCommand command)
        {
            BeginTransaction();
            var result = await _handler.InsertAsync(command);
            return Commit(result);
        }

        public virtual async Task<NotificationResult> UpdateAsync(UpdateShoplistCommand command)
        {
            BeginTransaction();
            var result = await _handler.UpdateAsync(command);
            return Commit(result);
        }

        public virtual async Task<NotificationResult> DeleteByIdAsync(int id)
        {
            BeginTransaction();
            var result = await _handler.DeleteByIdAsync(id);
            return Commit(result);
        }

        public virtual async Task<ShoplistCommandResult> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<IEnumerable<ShoplistCommandResult>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public virtual async Task<PaginatedList<PageShoplistCommandResult>> GetPageAsync(PageShoplistCommand command)
        {
            return await _repository.GetPageAsync(command);
        }

        public virtual async Task<IEnumerable<SelectListShoplistCommandResult>> GetSelectListAsync()
        {
            return await _repository.GetSelectListAsync();
        }

        public async Task<NotificationResult> CreateShoplistWithIngredientsAsync(InsertShoplistWithIngredientsCommand command)
        {
            BeginTransaction();
            var result = await _handler.CreateShoplistWithIngredients(command);
            return Commit(result);
        }

        public async Task<NotificationResult> CreateShoplistFromRecipesAsync(CreateShoplistFromRecipeIdCommand command)
        {
            var ingredientList = new List<InsertShoplistIngredientCommand>();
            foreach (var recipeId in command.RecipeId)
            {
                ingredientList.AddRange(
                    (await _recipeRepository.GetByIdAsync(recipeId))
                    .RecipeIngredients.Select(ri => new InsertShoplistIngredientCommand() {
                        Amount = ri.Amount,
                        AmountTypeId = ri.AmountTypeId,
                        IngredientId = ri.IngredientId
                    }).AsEnumerable());
            }
            //soh agrupar e BOA
            BeginTransaction();
            var result = await _handler.CreateShoplistWithIngredients(new InsertShoplistWithIngredientsCommand()
            {
                CreationDate = DateTime.Now,
                ShoplistsIngredients = ingredientList.GroupBy(i => new { i.IngredientId, i.AmountTypeId },
                    i => i.Amount
                ).Select(si => new InsertShoplistIngredientCommand()
                {
                    IngredientId = si.Key.IngredientId,
                    AmountTypeId = si.Key.AmountTypeId,
                    Amount = si.Sum()
                }).ToList()
            });
            return Commit(result);
        }
    }
}
