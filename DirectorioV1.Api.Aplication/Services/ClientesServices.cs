using DirectorioV1.Api.Aplication.Contracts.Services;
using DirectorioV1.Api.Business.Models;
using DirectorioV1.Api.DataAccess.Contracts.Entities;
using DirectorioV1.Api.DataAccess.Contracts.Repositories;
using DirectorioV1.Api.Business.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DirectorioV1.Api.Aplication.Services
{
    
    public class ClientesServices : IClientesServices
    {
        private readonly IClientesRepository _clientesRepository;
        private readonly ICategoriasRepository categoriasRepository;
        private readonly IClientesDireccionesRepository clientesDireccionesRepository;
        private readonly IClientesImagenesRepository clientesImagenesRepository;
        private readonly IPaisesRepository paisesRepository;
        private readonly IDepartamentosRepository departamentosRepository;
        private readonly ICiudadesRepository ciudadesRepository;
        private readonly IBarriosRepository barriosRepository;

        public ClientesServices(
            IClientesRepository clientesRepository,
            ICategoriasRepository categoriasRepository,
            IClientesDireccionesRepository clientesDireccionesRepository,
            IClientesImagenesRepository clientesImagenesRepository,
            IPaisesRepository paisesRepository,
            IDepartamentosRepository departamentosRepository,
            ICiudadesRepository ciudadesRepository,
            IBarriosRepository barriosRepository)
        {
            this._clientesRepository = clientesRepository;
            this.categoriasRepository = categoriasRepository;
            this.clientesDireccionesRepository = clientesDireccionesRepository;
            this.clientesImagenesRepository = clientesImagenesRepository;
            this.paisesRepository = paisesRepository;
            this.departamentosRepository = departamentosRepository;
            this.ciudadesRepository = ciudadesRepository;
            this.barriosRepository = barriosRepository;
        }

        public List<Clientes> ListadoDeClientes()
        {
            var cliente =  _clientesRepository.GetAll().ToList();            
            return ClientesMapper.map(cliente);
        }

        public async Task<Clientes> ClientePorId(int? id)
        {
            if (id == null)
                return null;
            var cliente = await _clientesRepository.GetByIdAsync(id.Value);
            return ClientesMapper.map(cliente);
        }

        public async Task<Clientes> CrearNuevoCliente(Clientes dto)
        {
            if (dto == null)
                return null;
            ClientesEntity clientesMap = ClientesMapper.map(dto);
            var cliente = await _clientesRepository.CreateAsync(clientesMap);
            return ClientesMapper.map(cliente);
        }

        public async Task<Clientes> EditarCliente(Clientes dto)
        {
            if (dto == null)
                return null;
            ClientesEntity clienteMap = ClientesMapper.map(dto);
            var pais = await _clientesRepository.UpdateAsync(clienteMap);
            return ClientesMapper.map(pais);
        }

        public void EliminarCliente(Clientes dto)
        {
            if (dto == null)
                return;
            var clientes = ClientesMapper.map(dto);
            this._clientesRepository.DeleteAsync(clientes);

        }

        public async Task<bool> ExisteCliente(int? id)
        {
            return await this._clientesRepository.ExistAsync(id.Value);
        }

        public IEnumerable<SelectListItem> ObtenerComboClientes()
        {
            return this._clientesRepository.ComboClientes();
        }

        public async Task<List<Clientes>> ListadoDeClientesConCategorias()
        {
            var clientesCat = await _clientesRepository.ListaClientesConCategorias();
            List<Clientes> rta = new List<Clientes>();

            foreach (var item in clientesCat)
            {
                Clientes ci = new Clientes();

                ci.Estado = item.Estado;
                ci.Id = item.Id;
                ci.Correo = item.Correo;
                ci.CategoriaId = item.CategoriaId;
                ci.Documento = item.Documento;
                ci.Fecha_Creacion = item.Fecha_Creacion.Value;
                ci.Nombre = item.Nombre;
                ci.Tipo_Documento = item.Tipo_Documento;
                ci.Categoria = CategoriasMapper.map(await this.categoriasRepository.GetByIdAsync(item.CategoriaId));

                rta.Add(ci);
            }
            return rta;
        }

        public async Task<ICollection<Clientes>> ListadoDeClientesConDatos()
        {

            var result = await _clientesRepository.ListaClientesConTodo();
            List<Clientes> listClientes = new List<Clientes>();
            foreach (var item in result)
            {
                Clientes cl = new Clientes();
                cl.CategoriaId = item.CategoriaId;
                cl.Correo = item.Correo;
                var di = await this.clientesDireccionesRepository.ListaDireccionesPorClientes(item.Id);
                cl.Direcciones = await ToDirecciones(di);
                cl.Documento = item.Documento;
                cl.Estado = item.Estado;
                cl.Fecha_Creacion = item.Fecha_Creacion.Value;
                cl.Id = item.Id;
                cl.Imagenes = ClientesImagenesMapper.map( await this.clientesImagenesRepository.ListaImagenesPorCliente(item.Id));
                cl.Nombre = item.Nombre;
                cl.Tipo_Documento = item.Tipo_Documento;
                cl.Categoria = CategoriasMapper.map(await this.categoriasRepository.GetByIdAsync(item.CategoriaId));
                listClientes.Add(cl);
            }
            return listClientes;
           
           
        }

        private async Task<List<ClientesDirecciones>> ToDirecciones(ICollection<ClientesDireccionesEntity> entity)
        {
            List<ClientesDirecciones> result = new List<ClientesDirecciones>();
            if (entity == null)
                return result;
            foreach (var item in entity)
            {
                ClientesDirecciones cd = new ClientesDirecciones();
                cd.BarrioId = item.BarrioId;
                cd.CiudadId = item.CiudadId;
                cd.PaisId = item.PaisId;
                cd.DepartamentoId = item.DepartamentoId;
                cd.ClienteId = item.ClienteId;
                cd.Pais = PaisesMapper.map(await this.paisesRepository.GetByIdAsync(item.PaisId));
                cd.Departamento = DepartamentosMapper.map(await this.departamentosRepository.GetByIdAsync(item.DepartamentoId));
                cd.Ciudad = CiudadesMapper.map(await this.ciudadesRepository.GetByIdAsync(item.CiudadId));
                cd.Barrio = BarriosMapper.map(await this.barriosRepository.GetByIdAsync(item.BarrioId));
                cd.Direccion_A = item.Direccion_A;
                cd.Direccion_B = item.Direccion_B;
                cd.Direccion_Compuesta = item.Direccion_Compuesta;
                cd.Direccion_Observacion = item.Direccion_Observacion;
                cd.Direccion_Tipo_A = item.Direccion_Tipo_A;
                cd.Direccion_Tipo_B = item.Direccion_Tipo_B;
                cd.Estado = item.Estado;
                cd.Id = item.Id;
                cd.Latitud = item.Latitud;
                cd.Longitud = item.Longitud;
                cd.Servicio_Domicilio = item.Servicio_Domicilio;
                cd.Telefono = item.Telefono;
                cd.Horario = item.Horario;
                cd.Cliente = ClientesMapper.map(await this._clientesRepository.GetByIdAsync(item.ClienteId));
                result.Add(cd);
            }

            return result;
        }
    }
}
