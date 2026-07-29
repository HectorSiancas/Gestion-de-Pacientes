using Microsoft.AspNetCore.Components;
using Radzen;
using System.Text.Encodings.Web;
using System.Text;
using Shared.Models.Clinica;
using System.Text.Json;
using System.Buffers.Text;
using System;
using System.Net.Http;

namespace SistemaClinico.Services
{
    public partial class dbService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;

        public dbService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            //this.baseUri = new Uri($"{navigationManager.BaseUri}odata/db_ab7f92_desarrollog6/");
            this.baseUri = new Uri($"https://japisistemas-c3hsfydjcvbrb6ec.eastus-01.azurewebsites.net/api/");
            //this.baseUri = new Uri($"http://localhost:8080/api/");
        }


        public async System.Threading.Tasks.Task ExportCitaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/cita/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/cita/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportCitaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/cita/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/cita/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetCita(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<Citum>> GetCita(Query query)
        {
            return await GetCita(filter: $"{query.Filter}", orderby: $"{query.OrderBy}", top: query.Top, skip: query.Skip, count: query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<Citum>> GetCita(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Cita");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: filter, top: top, skip: skip, orderby: orderby, expand: expand, select: select, count: count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetCita(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Citum>>(response);
        }

        partial void OnCreateCitum(HttpRequestMessage requestMessage);

        public async Task<Citum> CreateCitum(Citum citum = default(Citum))
        {
            var uri = new Uri(baseUri, $"Cita");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(citum), Encoding.UTF8, "application/json");

            OnCreateCitum(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Citum>(response);
        }

        partial void OnDeleteCitum(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteCitum(int idCita = default(int))
        {
            var uri = new Uri(baseUri, $"Cita({idCita})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteCitum(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetCitumByIdCita(HttpRequestMessage requestMessage);

        public async Task<Citum> GetCitumByIdCita(string expand = default(string), int idCita = default(int))
        {
            var uri = new Uri(baseUri, $"Cita({idCita})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: null, top: null, skip: null, orderby: null, expand: expand, select: null, count: null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetCitumByIdCita(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Citum>(response);
        }

        partial void OnUpdateCitum(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> UpdateCitum(int idCita = default(int), Citum citum = default(Citum))
        {
            var uri = new Uri(baseUri, $"Cita({idCita})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(citum), Encoding.UTF8, "application/json");

            OnUpdateCitum(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportDiagnosticosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/diagnosticos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/diagnosticos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportDiagnosticosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/diagnosticos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/diagnosticos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetDiagnosticos(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<Diagnostico>> GetDiagnosticos(Query query)
        {
            return await GetDiagnosticos(filter: $"{query.Filter}", orderby: $"{query.OrderBy}", top: query.Top, skip: query.Skip, count: query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<Diagnostico>> GetDiagnosticos(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Diagnosticos");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: filter, top: top, skip: skip, orderby: orderby, expand: expand, select: select, count: count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDiagnosticos(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Diagnostico>>(response);
        }

        partial void OnCreateDiagnostico(HttpRequestMessage requestMessage);

        public async Task<Diagnostico> CreateDiagnostico(Diagnostico diagnostico = default(Diagnostico))
        {
            var uri = new Uri(baseUri, $"Diagnosticos");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(diagnostico), Encoding.UTF8, "application/json");

            OnCreateDiagnostico(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Diagnostico>(response);
        }

        partial void OnDeleteDiagnostico(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteDiagnostico(int idDiagnostico = default(int))
        {
            var uri = new Uri(baseUri, $"Diagnosticos({idDiagnostico})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteDiagnostico(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetDiagnosticoByIdDiagnostico(HttpRequestMessage requestMessage);

        public async Task<Diagnostico> GetDiagnosticoByIdDiagnostico(string expand = default(string), int idDiagnostico = default(int))
        {
            var uri = new Uri(baseUri, $"Diagnosticos({idDiagnostico})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: null, top: null, skip: null, orderby: null, expand: expand, select: null, count: null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDiagnosticoByIdDiagnostico(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Diagnostico>(response);
        }

        partial void OnUpdateDiagnostico(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> UpdateDiagnostico(int idDiagnostico = default(int), Diagnostico diagnostico = default(Diagnostico))
        {
            var uri = new Uri(baseUri, $"Diagnosticos({idDiagnostico})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(diagnostico), Encoding.UTF8, "application/json");

            OnUpdateDiagnostico(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportDiaSemanasToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/diasemanas/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/diasemanas/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportDiaSemanasToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/diasemanas/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/diasemanas/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetDiaSemanas(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<DiaSemana>> GetDiaSemanas(Query query)
        {
            return await GetDiaSemanas(filter: $"{query.Filter}", orderby: $"{query.OrderBy}", top: query.Top, skip: query.Skip, count: query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<DiaSemana>> GetDiaSemanas(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"DiaSemanas");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: filter, top: top, skip: skip, orderby: orderby, expand: expand, select: select, count: count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDiaSemanas(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<DiaSemana>>(response);
        }

        partial void OnCreateDiaSemana(HttpRequestMessage requestMessage);

        public async Task<DiaSemana> CreateDiaSemana(DiaSemana diaSemana = default(DiaSemana))
        {
            var uri = new Uri(baseUri, $"DiaSemanas");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(diaSemana), Encoding.UTF8, "application/json");

            OnCreateDiaSemana(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<DiaSemana>(response);
        }

        partial void OnDeleteDiaSemana(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteDiaSemana(int idDiaSemana = default(int))
        {
            var uri = new Uri(baseUri, $"DiaSemanas({idDiaSemana})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteDiaSemana(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetDiaSemanaByIdDiaSemana(HttpRequestMessage requestMessage);

        public async Task<DiaSemana> GetDiaSemanaByIdDiaSemana(string expand = default(string), int idDiaSemana = default(int))
        {
            var uri = new Uri(baseUri, $"DiaSemanas({idDiaSemana})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: null, top: null, skip: null, orderby: null, expand: expand, select: null, count: null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDiaSemanaByIdDiaSemana(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<DiaSemana>(response);
        }

        partial void OnUpdateDiaSemana(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> UpdateDiaSemana(int idDiaSemana = default(int), DiaSemana diaSemana = default(DiaSemana))
        {
            var uri = new Uri(baseUri, $"DiaSemanas({idDiaSemana})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(diaSemana), Encoding.UTF8, "application/json");

            OnUpdateDiaSemana(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportEmpleadosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/empleados/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/empleados/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportEmpleadosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/empleados/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/empleados/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetEmpleados(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<Empleado>> GetEmpleados(Query query)
        {
            return await GetEmpleados(filter: $"{query.Filter}", orderby: $"{query.OrderBy}", top: query.Top, skip: query.Skip, count: query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<Empleado>> GetEmpleados(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Empleados");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: filter, top: top, skip: skip, orderby: orderby, expand: expand, select: select, count: count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEmpleados(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Empleado>>(response);
        }

        partial void OnCreateEmpleado(HttpRequestMessage requestMessage);

        public async Task<Empleado> CreateEmpleado(Empleado empleado = default(Empleado))
        {
            var uri = new Uri(baseUri, $"Empleados");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(empleado), Encoding.UTF8, "application/json");

            OnCreateEmpleado(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Empleado>(response);
        }

        partial void OnDeleteEmpleado(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteEmpleado(int idEmpleado = default(int))
        {
            var uri = new Uri(baseUri, $"Empleados({idEmpleado})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteEmpleado(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetEmpleadoByIdEmpleado(HttpRequestMessage requestMessage);

        public async Task<Empleado> GetEmpleadoByIdEmpleado(string expand = default(string), int idEmpleado = default(int))
        {
            var uri = new Uri(baseUri, $"Empleados({idEmpleado})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: null, top: null, skip: null, orderby: null, expand: expand, select: null, count: null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEmpleadoByIdEmpleado(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Empleado>(response);
        }

        partial void OnUpdateEmpleado(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> UpdateEmpleado(int idEmpleado = default(int), Empleado empleado = default(Empleado))
        {
            var uri = new Uri(baseUri, $"Empleados({idEmpleado})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(empleado), Encoding.UTF8, "application/json");

            OnUpdateEmpleado(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportEspecialidadsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/especialidads/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/especialidads/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportEspecialidadsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/especialidads/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/especialidads/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetEspecialidads(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<Especialidad>> GetEspecialidads(Query query)
        {
            return await GetEspecialidads(filter: $"{query.Filter}", orderby: $"{query.OrderBy}", top: query.Top, skip: query.Skip, count: query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<Especialidad>> GetEspecialidads(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Especialidads");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: filter, top: top, skip: skip, orderby: orderby, expand: expand, select: select, count: count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEspecialidads(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Especialidad>>(response);
        }

        partial void OnCreateEspecialidad(HttpRequestMessage requestMessage);

        public async Task<Especialidad> CreateEspecialidad(Especialidad especialidad = default(Especialidad))
        {
            var uri = new Uri(baseUri, $"Especialidads");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(especialidad), Encoding.UTF8, "application/json");

            OnCreateEspecialidad(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Especialidad>(response);
        }

        partial void OnDeleteEspecialidad(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteEspecialidad(int idEspecialidad = default(int))
        {
            var uri = new Uri(baseUri, $"Especialidads({idEspecialidad})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteEspecialidad(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetEspecialidadByIdEspecialidad(HttpRequestMessage requestMessage);

        public async Task<Especialidad> GetEspecialidadByIdEspecialidad(string expand = default(string), int idEspecialidad = default(int))
        {
            var uri = new Uri(baseUri, $"Especialidads({idEspecialidad})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: null, top: null, skip: null, orderby: null, expand: expand, select: null, count: null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEspecialidadByIdEspecialidad(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Especialidad>(response);
        }

        partial void OnUpdateEspecialidad(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> UpdateEspecialidad(int idEspecialidad = default(int), Especialidad especialidad = default(Especialidad))
        {
            var uri = new Uri(baseUri, $"Especialidads({idEspecialidad})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(especialidad), Encoding.UTF8, "application/json");

            OnUpdateEspecialidad(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportHistoriaClinicasToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/historiaclinicas/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/historiaclinicas/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportHistoriaClinicasToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/historiaclinicas/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/historiaclinicas/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetHistoriaClinicas(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<HistoriaClinica>> GetHistoriaClinicas(Query query)
        {
            return await GetHistoriaClinicas(filter: $"{query.Filter}", orderby: $"{query.OrderBy}", top: query.Top, skip: query.Skip, count: query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<HistoriaClinica>> GetHistoriaClinicas(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"HistoriaClinicas");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: filter, top: top, skip: skip, orderby: orderby, expand: expand, select: select, count: count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetHistoriaClinicas(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<HistoriaClinica>>(response);
        }

        partial void OnCreateHistoriaClinica(HttpRequestMessage requestMessage);

        public async Task<HistoriaClinica> CreateHistoriaClinica(HistoriaClinica historiaClinica = default(HistoriaClinica))
        {
            var uri = new Uri(baseUri, $"HistoriaClinicas");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(historiaClinica), Encoding.UTF8, "application/json");

            OnCreateHistoriaClinica(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<HistoriaClinica>(response);
        }

        partial void OnDeleteHistoriaClinica(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteHistoriaClinica(int idHistoriaClinica = default(int))
        {
            var uri = new Uri(baseUri, $"HistoriaClinicas({idHistoriaClinica})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteHistoriaClinica(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetHistoriaClinicaByIdHistoriaClinica(HttpRequestMessage requestMessage);

        public async Task<HistoriaClinica> GetHistoriaClinicaByIdHistoriaClinica(string expand = default(string), int idHistoriaClinica = default(int))
        {
            var uri = new Uri(baseUri, $"HistoriaClinicas({idHistoriaClinica})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: null, top: null, skip: null, orderby: null, expand: expand, select: null, count: null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetHistoriaClinicaByIdHistoriaClinica(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<HistoriaClinica>(response);
        }

        partial void OnUpdateHistoriaClinica(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> UpdateHistoriaClinica(int idHistoriaClinica = default(int), HistoriaClinica historiaClinica = default(HistoriaClinica))
        {
            var uri = new Uri(baseUri, $"HistoriaClinicas({idHistoriaClinica})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(historiaClinica), Encoding.UTF8, "application/json");

            OnUpdateHistoriaClinica(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportHorasToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/horas/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/horas/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportHorasToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/horas/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/horas/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetHoras(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<Hora>> GetHoras(Query query)
        {
            return await GetHoras(filter: $"{query.Filter}", orderby: $"{query.OrderBy}", top: query.Top, skip: query.Skip, count: query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<Hora>> GetHoras(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Horas");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: filter, top: top, skip: skip, orderby: orderby, expand: expand, select: select, count: count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetHoras(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Hora>>(response);
        }

        partial void OnCreateHora(HttpRequestMessage requestMessage);

        public async Task<Hora> CreateHora(Hora hora = default(Hora))
        {
            var uri = new Uri(baseUri, $"Horas");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(hora), Encoding.UTF8, "application/json");

            OnCreateHora(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Hora>(response);
        }

        partial void OnDeleteHora(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteHora(int idHora = default(int))
        {
            var uri = new Uri(baseUri, $"Horas({idHora})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteHora(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetHoraByIdHora(HttpRequestMessage requestMessage);

        public async Task<Hora> GetHoraByIdHora(string expand = default(string), int idHora = default(int))
        {
            var uri = new Uri(baseUri, $"Horas({idHora})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: null, top: null, skip: null, orderby: null, expand: expand, select: null, count: null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetHoraByIdHora(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Hora>(response);
        }

        partial void OnUpdateHora(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> UpdateHora(int idHora = default(int), Hora hora = default(Hora))
        {
            var uri = new Uri(baseUri, $"Horas({idHora})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(hora), Encoding.UTF8, "application/json");

            OnUpdateHora(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportHorarioAtencionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/horarioatencions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/horarioatencions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportHorarioAtencionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/horarioatencions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/horarioatencions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetHorarioAtencions(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<HorarioAtencion>> GetHorarioAtencions(Query query)
        {
            return await GetHorarioAtencions(filter: $"{query.Filter}", orderby: $"{query.OrderBy}", top: query.Top, skip: query.Skip, count: query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<HorarioAtencion>> GetHorarioAtencions(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"HorarioAtencions");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: filter, top: top, skip: skip, orderby: orderby, expand: expand, select: select, count: count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetHorarioAtencions(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<HorarioAtencion>>(response);
        }

        partial void OnCreateHorarioAtencion(HttpRequestMessage requestMessage);

        public async Task<HorarioAtencion> CreateHorarioAtencion(HorarioAtencion horarioAtencion = default(HorarioAtencion))
        {
            var uri = new Uri(baseUri, $"HorarioAtencions");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(horarioAtencion), Encoding.UTF8, "application/json");

            OnCreateHorarioAtencion(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<HorarioAtencion>(response);
        }

        partial void OnDeleteHorarioAtencion(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteHorarioAtencion(int idHorarioAtencion = default(int))
        {
            var uri = new Uri(baseUri, $"HorarioAtencions({idHorarioAtencion})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteHorarioAtencion(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetHorarioAtencionByIdHorarioAtencion(HttpRequestMessage requestMessage);

        public async Task<HorarioAtencion> GetHorarioAtencionByIdHorarioAtencion(string expand = default(string), int idHorarioAtencion = default(int))
        {
            var uri = new Uri(baseUri, $"HorarioAtencions({idHorarioAtencion})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: null, top: null, skip: null, orderby: null, expand: expand, select: null, count: null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetHorarioAtencionByIdHorarioAtencion(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<HorarioAtencion>(response);
        }

        partial void OnUpdateHorarioAtencion(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> UpdateHorarioAtencion(int idHorarioAtencion = default(int), HorarioAtencion horarioAtencion = default(HorarioAtencion))
        {
            var uri = new Uri(baseUri, $"HorarioAtencions({idHorarioAtencion})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(horarioAtencion), Encoding.UTF8, "application/json");

            OnUpdateHorarioAtencion(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportMedicosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/medicos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/medicos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMedicosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/medicos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/medicos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetMedicos(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<Medico>> GetMedicos(Query query)
        {
            return await GetMedicos(filter: $"{query.Filter}", orderby: $"{query.OrderBy}", top: query.Top, skip: query.Skip, count: query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<Medico>> GetMedicos(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Medicos");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: filter, top: top, skip: skip, orderby: orderby, expand: expand, select: select, count: count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMedicos(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Medico>>(response);
        }

        partial void OnCreateMedico(HttpRequestMessage requestMessage);

        public async Task<Medico> CreateMedico(Medico medico = default(Medico))
        {
            var uri = new Uri(baseUri, $"Medicos");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(medico), Encoding.UTF8, "application/json");

            OnCreateMedico(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Medico>(response);
        }

        partial void OnDeleteMedico(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteMedico(int idMedico = default(int))
        {
            var uri = new Uri(baseUri, $"Medicos({idMedico})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMedico(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetMedicoByIdMedico(HttpRequestMessage requestMessage);

        public async Task<Medico> GetMedicoByIdMedico(string expand = default(string), int idMedico = default(int))
        {
            var uri = new Uri(baseUri, $"Medicos({idMedico})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: null, top: null, skip: null, orderby: null, expand: expand, select: null, count: null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMedicoByIdMedico(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Medico>(response);
        }

        partial void OnUpdateMedico(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> UpdateMedico(int idMedico = default(int), Medico medico = default(Medico))
        {
            var uri = new Uri(baseUri, $"Medicos({idMedico})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(medico), Encoding.UTF8, "application/json");

            OnUpdateMedico(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportMenusToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/menus/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/menus/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMenusToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/menus/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/menus/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetMenus(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<Menu>> GetMenus(Query query)
        {
            return await GetMenus(filter: $"{query.Filter}", orderby: $"{query.OrderBy}", top: query.Top, skip: query.Skip, count: query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<Menu>> GetMenus(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Menus");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: filter, top: top, skip: skip, orderby: orderby, expand: expand, select: select, count: count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMenus(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Menu>>(response);
        }

        partial void OnCreateMenu(HttpRequestMessage requestMessage);

        public async Task<Menu> CreateMenu(Menu menu = default(Menu))
        {
            var uri = new Uri(baseUri, $"Menus");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(menu), Encoding.UTF8, "application/json");

            OnCreateMenu(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Menu>(response);
        }

        partial void OnDeleteMenu(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteMenu(int idMenu = default(int))
        {
            var uri = new Uri(baseUri, $"Menus({idMenu})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMenu(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetMenuByIdMenu(HttpRequestMessage requestMessage);

        public async Task<Menu> GetMenuByIdMenu(string expand = default(string), int idMenu = default(int))
        {
            var uri = new Uri(baseUri, $"Menus({idMenu})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: null, top: null, skip: null, orderby: null, expand: expand, select: null, count: null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMenuByIdMenu(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Menu>(response);
        }

        partial void OnUpdateMenu(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> UpdateMenu(int idMenu = default(int), Menu menu = default(Menu))
        {
            var uri = new Uri(baseUri, $"Menus({idMenu})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(menu), Encoding.UTF8, "application/json");

            OnUpdateMenu(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportPacientesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/pacientes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/pacientes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportPacientesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/pacientes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/pacientes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetPacientes(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<Paciente>> GetPacientes(Query query)
        {
            return await GetPacientes(filter: $"{query.Filter}", orderby: $"{query.OrderBy}", top: query.Top, skip: query.Skip, count: query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<Paciente>> GetPacientes(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Pacientes");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: filter, top: top, skip: skip, orderby: orderby, expand: expand, select: select, count: count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetPacientes(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            var ddd = HttpResponseMessageExtensions.ReadAsync<ODataServiceResult<Paciente>>(response);

            if (response.IsSuccessStatusCode)
            {
                var response2 = await DeserializarRespuesta<List<Paciente>>(response, OpcionesPorDefectoJSON);
                var oDataServiceResult = new ODataServiceResult<Paciente> { Count = response2.Count, Value = response2 };
                return oDataServiceResult;
            }
            else
            {
                return new ODataServiceResult<Paciente>();
                //return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Paciente>>(response);
            }
        }

        private JsonSerializerOptions OpcionesPorDefectoJSON => new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        private async Task<T> DeserializarRespuesta<T>(HttpResponseMessage httpResponse, JsonSerializerOptions jsonSerializerOptions)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, jsonSerializerOptions);
        }

        partial void OnCreatePaciente(HttpRequestMessage requestMessage);

        public async Task<Paciente> CreatePaciente(Paciente paciente = default(Paciente))
        {
            var uri = new Uri(baseUri, $"Pacientes");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(paciente), Encoding.UTF8, "application/json");

            OnCreatePaciente(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Paciente>(response);
        }

        partial void OnDeletePaciente(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeletePaciente(int idPaciente = default(int))
        {
            var uri = new Uri(baseUri, $"Pacientes({idPaciente})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeletePaciente(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetPacienteByIdPaciente(HttpRequestMessage requestMessage);

        public async Task<Paciente> GetPacienteByIdPaciente(string expand = default(string), int idPaciente = default(int))
        {
            var uri = new Uri(baseUri, $"Pacientes/{idPaciente}");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: null, top: null, skip: null, orderby: null, expand: expand, select: null, count: null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetPacienteByIdPaciente(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);


            if (response.IsSuccessStatusCode)
            {
                var response2 = await DeserializarRespuesta<Paciente>(response, OpcionesPorDefectoJSON);
                //var oDataServiceResult = new ODataServiceResult<Paciente> { Count = response2.Count, Value = response2 };
                return response2;
            }
            else
            {
                return null;
                //return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Paciente>>(response);
            }

            //return await Radzen.HttpResponseMessageExtensions.ReadAsync<Paciente>(response);
        }

        partial void OnUpdatePaciente(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> UpdatePaciente(int idPaciente = default(int), Paciente paciente = default(Paciente))
        {
            var uri = new Uri(baseUri, $"Pacientes/{idPaciente}");

            //var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, uri);


            //httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(paciente), Encoding.UTF8, "application/json");

            //OnUpdatePaciente(httpRequestMessage);

            //return await httpClient.SendAsync(httpRequestMessage);


            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var enviarJSON = JsonSerializer.Serialize(paciente, options);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PutAsync(uri, enviarContent);
            //return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
            return await httpClient.SendAsync(responseHttp.RequestMessage);

        }

        public async System.Threading.Tasks.Task ExportPermisosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/permisos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/permisos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportPermisosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/permisos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/permisos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetPermisos(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<Permiso>> GetPermisos(Query query)
        {
            return await GetPermisos(filter: $"{query.Filter}", orderby: $"{query.OrderBy}", top: query.Top, skip: query.Skip, count: query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<Permiso>> GetPermisos(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Permisos");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: filter, top: top, skip: skip, orderby: orderby, expand: expand, select: select, count: count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetPermisos(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Permiso>>(response);
        }

        partial void OnCreatePermiso(HttpRequestMessage requestMessage);

        public async Task<Permiso> CreatePermiso(Permiso permiso = default(Permiso))
        {
            var uri = new Uri(baseUri, $"Permisos");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(permiso), Encoding.UTF8, "application/json");

            OnCreatePermiso(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Permiso>(response);
        }

        partial void OnDeletePermiso(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeletePermiso(int idMenu = default(int), int idEmpleado = default(int))
        {
            var uri = new Uri(baseUri, $"Permisos(IdMenu={idMenu},IdEmpleado={idEmpleado})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeletePermiso(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetPermisoByIdMenuAndIdEmpleado(HttpRequestMessage requestMessage);

        public async Task<Permiso> GetPermisoByIdMenuAndIdEmpleado(string expand = default(string), int idMenu = default(int), int idEmpleado = default(int))
        {
            var uri = new Uri(baseUri, $"Permisos(IdMenu={idMenu},IdEmpleado={idEmpleado})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: null, top: null, skip: null, orderby: null, expand: expand, select: null, count: null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetPermisoByIdMenuAndIdEmpleado(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Permiso>(response);
        }

        partial void OnUpdatePermiso(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> UpdatePermiso(int idMenu = default(int), int idEmpleado = default(int), Permiso permiso = default(Permiso))
        {
            var uri = new Uri(baseUri, $"Permisos(IdMenu={idMenu},IdEmpleado={idEmpleado})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(permiso), Encoding.UTF8, "application/json");

            OnUpdatePermiso(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTipoEmpleadosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/tipoempleados/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/tipoempleados/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTipoEmpleadosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/db_ab7f92_desarrollog6/tipoempleados/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/db_ab7f92_desarrollog6/tipoempleados/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTipoEmpleados(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<TipoEmpleado>> GetTipoEmpleados(Query query)
        {
            return await GetTipoEmpleados(filter: $"{query.Filter}", orderby: $"{query.OrderBy}", top: query.Top, skip: query.Skip, count: query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<TipoEmpleado>> GetTipoEmpleados(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TipoEmpleados");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: filter, top: top, skip: skip, orderby: orderby, expand: expand, select: select, count: count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTipoEmpleados(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<TipoEmpleado>>(response);
        }

        partial void OnCreateTipoEmpleado(HttpRequestMessage requestMessage);

        public async Task<TipoEmpleado> CreateTipoEmpleado(TipoEmpleado tipoEmpleado = default(TipoEmpleado))
        {
            var uri = new Uri(baseUri, $"TipoEmpleados");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tipoEmpleado), Encoding.UTF8, "application/json");

            OnCreateTipoEmpleado(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TipoEmpleado>(response);
        }

        partial void OnDeleteTipoEmpleado(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTipoEmpleado(int idTipoEmpleado = default(int))
        {
            var uri = new Uri(baseUri, $"TipoEmpleados({idTipoEmpleado})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTipoEmpleado(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTipoEmpleadoByIdTipoEmpleado(HttpRequestMessage requestMessage);

        public async Task<TipoEmpleado> GetTipoEmpleadoByIdTipoEmpleado(string expand = default(string), int idTipoEmpleado = default(int))
        {
            var uri = new Uri(baseUri, $"TipoEmpleados({idTipoEmpleado})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter: null, top: null, skip: null, orderby: null, expand: expand, select: null, count: null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTipoEmpleadoByIdTipoEmpleado(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<TipoEmpleado>(response);
        }

        partial void OnUpdateTipoEmpleado(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> UpdateTipoEmpleado(int idTipoEmpleado = default(int), TipoEmpleado tipoEmpleado = default(TipoEmpleado))
        {
            var uri = new Uri(baseUri, $"TipoEmpleados({idTipoEmpleado})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tipoEmpleado), Encoding.UTF8, "application/json");

            OnUpdateTipoEmpleado(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
    }
}
