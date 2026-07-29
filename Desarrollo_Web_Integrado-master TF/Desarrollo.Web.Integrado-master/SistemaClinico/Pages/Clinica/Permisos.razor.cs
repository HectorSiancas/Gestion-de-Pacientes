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
    public partial class Permisos
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
        protected IEnumerable<Permiso> permisos;

        protected RadzenDataGrid<Permiso> grid0;
        protected int count;

        protected async Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                //var result = await _dbService.GetPermisos(filter: $"{args.Filter}", expand: "Menu,Empleado", orderby: $"{args.OrderBy}", top: args.Top, skip: args.Skip, count:args.Top != null && args.Skip != null);
                //permisos = result.Value.AsODataEnumerable();
                //count = result.Count;
                var httpResponse = await _service.Get<List<Permiso>>($"api/Permisos");
                if (httpResponse.Error)
                {
                    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = await httpResponse.ObtenerMensajeError() });
                }
                else
                {
                    permisos = httpResponse.Response;
                    count = httpResponse.Response.Count;
                }
            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load Permisos" });
            }
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddPermiso>("Agregar Permiso", null);
            await grid0.Reload();
        }

        protected async Task EditRow(Permiso args)
        {
            await DialogService.OpenAsync<EditPermiso>("Edit Permiso", new Dictionary<string, object> { {"IdMenu", args.IdMenu}, {"IdEmpleado", args.IdEmpleado} });
            await grid0.Reload();
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, Permiso permiso)
        {
            try
            {
                if (await DialogService.Confirm("¿Está seguro de que desea eliminar este registro?", "Confirmar", new ConfirmOptions() { OkButtonText = "OK", CancelButtonText = "CANCELAR" }) == true)
                {
                    var deleteResult = await _dbService.DeletePermiso(idMenu:permiso.IdMenu, idEmpleado:permiso.IdEmpleado);

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
                    Detail = $"No se puede eliminar Permiso"
                });
            }
        }
    }
}