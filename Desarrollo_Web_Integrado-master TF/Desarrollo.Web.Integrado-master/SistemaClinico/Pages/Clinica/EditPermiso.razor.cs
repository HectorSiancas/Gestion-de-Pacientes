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
    public partial class EditPermiso
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

        [Parameter]
        public int IdEmpleado { get; set; }

        protected override async Task OnInitializedAsync()
        {
            permiso = await _dbService.GetPermisoByIdMenuAndIdEmpleado(idMenu:IdMenu, idEmpleado:IdEmpleado);
        }
        protected bool errorVisible;
        protected Permiso permiso;

        protected IEnumerable<Menu> menusForIdMenu;

        protected IEnumerable<Shared.Models.Clinica.Empleado> empleadosForIdEmpleado;


        protected int menusForIdMenuCount;
        protected Menu menusForIdMenuValue;
        protected async Task menusForIdMenuLoadData(LoadDataArgs args)
        {
            try
            {
                var result = await _dbService.GetMenus(top: args.Top, skip: args.Skip, count:args.Top != null && args.Skip != null, filter: $"contains(Nombre, '{(!string.IsNullOrEmpty(args.Filter) ? args.Filter : "")}')", orderby: $"{args.OrderBy}");
                menusForIdMenu = result.Value.AsODataEnumerable();
                menusForIdMenuCount = result.Count;

            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load Menu" });
            }
        }

        protected int empleadosForIdEmpleadoCount;
        protected Shared.Models.Clinica.Empleado empleadosForIdEmpleadoValue;
        protected async Task empleadosForIdEmpleadoLoadData(LoadDataArgs args)
        {
            try
            {
                var result = await _dbService.GetEmpleados(top: args.Top, skip: args.Skip, count:args.Top != null && args.Skip != null, filter: $"contains(ApMaterno, '{(!string.IsNullOrEmpty(args.Filter) ? args.Filter : "")}')", orderby: $"{args.OrderBy}");
                empleadosForIdEmpleado = result.Value.AsODataEnumerable();
                empleadosForIdEmpleadoCount = result.Count;

            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load Empleado" });
            }
        }
        protected async Task FormSubmit()
        {
            try
            {
                await _dbService.UpdatePermiso(idMenu:IdMenu, idEmpleado:IdEmpleado, permiso);
                DialogService.Close(permiso);
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