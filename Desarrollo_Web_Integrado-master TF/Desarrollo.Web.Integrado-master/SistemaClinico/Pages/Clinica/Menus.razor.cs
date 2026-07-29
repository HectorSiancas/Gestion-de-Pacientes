using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using SistemaClinico.Services;
using Shared.Models.Clinica;

namespace SistemaClinico.Pages.Clinica
{
    public partial class Menus
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        public dbService _dbService { get; set; }
        [Inject]
        public IService _service { get; set; }
        protected IEnumerable<Menu> menus;

        protected RadzenDataGrid<Menu> grid0;
        protected int count;

        protected async Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var result = await _dbService.GetMenus(filter: $"{args.Filter}", expand: "Menu1", orderby: $"{args.OrderBy}", top: args.Top, skip: args.Skip, count:args.Top != null && args.Skip != null);
                menus = result.Value.AsODataEnumerable();
                count = result.Count;
            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load Menus" });
            }
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddMenu>("Agregar Menu", null);
            await grid0.Reload();
        }

        protected async Task EditRow(Menu args)
        {
            await DialogService.OpenAsync<EditMenu>("Edit Menu", new Dictionary<string, object> { {"IdMenu", args.IdMenu} });
            await grid0.Reload();
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, Menu menu)
        {
            try
            {
                if (await DialogService.Confirm("¿Está seguro de que desea eliminar este registro?", "Confirmar", new ConfirmOptions() { OkButtonText = "OK", CancelButtonText = "CANCELAR" }) == true)
                {
                    var deleteResult = await _dbService.DeleteMenu(idMenu:menu.IdMenu);

                    if (deleteResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (Exception ex)
            {
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Error,
                    Summary = $"Error",
                    Detail = $"No se puede eliminar Menu"
                });
            }
        }
    }
}