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
    public partial class EditMenu
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

        [Parameter]
        public int IdMenu { get; set; }

        protected override async Task OnInitializedAsync()
        {
            menu = await _dbService.GetMenuByIdMenu(idMenu:IdMenu);
        }
        protected bool errorVisible;
        protected Menu menu;

        protected IEnumerable<Menu> menusForIdMenuParent;


        protected int menusForIdMenuParentCount;
        protected Menu menusForIdMenuParentValue;
        protected async Task menusForIdMenuParentLoadData(LoadDataArgs args)
        {
            try
            {
                var result = await _dbService.GetMenus(top: args.Top, skip: args.Skip, count:args.Top != null && args.Skip != null, filter: $"contains(Nombre, '{(!string.IsNullOrEmpty(args.Filter) ? args.Filter : "")}')", orderby: $"{args.OrderBy}");
                menusForIdMenuParent = result.Value.AsODataEnumerable();
                menusForIdMenuParentCount = result.Count;

            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load Menu1" });
            }
        }
        protected async Task FormSubmit()
        {
            try
            {
                await _dbService.UpdateMenu(idMenu:IdMenu, menu);
                DialogService.Close(menu);
            }
            catch (Exception ex)
            {
                errorVisible = true;
            }
        }

        protected async Task CancelButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}