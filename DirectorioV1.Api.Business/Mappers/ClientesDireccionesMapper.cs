using DirectorioV1.Api.Business.Models;
using DirectorioV1.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.Business.Mappers
{
    public static class ClientesDireccionesMapper
    {
        public static ClientesDireccionesEntity map(ClientesDirecciones dto)
        {
            if (dto == null)
                return null;
            return new ClientesDireccionesEntity()
            {
                Id = dto.Id,
                Estado = dto.Estado,
                Latitud = dto.Latitud,
                Longitud = dto.Longitud,
                BarrioId = dto.BarrioId,
                CiudadId = dto.CiudadId,
                DepartamentoId = dto.DepartamentoId,
                Direccion_A = dto.Direccion_A,
                Direccion_B = dto.Direccion_B,
                Direccion_Compuesta =  dto.Direccion_Tipo_A+" "+dto.Direccion_A+" "+dto.Direccion_Tipo_B+" "+dto.Direccion_B+" "+dto.Direccion_Observacion,
                Direccion_Observacion = dto.Direccion_Observacion,
                Direccion_Tipo_A = dto.Direccion_Tipo_A,
                Direccion_Tipo_B = dto.Direccion_Tipo_B,
                PaisId = dto.PaisId,
                Telefono = dto.Telefono,
                Servicio_Domicilio = dto.Servicio_Domicilio,
                ClienteId = dto.ClienteId,
            };
        }

        public static ClientesDirecciones map(ClientesDireccionesEntity dto)
        {
            if (dto == null)
                return null;
            return new ClientesDirecciones()
            {
                Id = dto.Id,
                Estado = dto.Estado,
                Latitud = dto.Latitud,
                Longitud = dto.Longitud,
                BarrioId = dto.BarrioId,
                CiudadId = dto.CiudadId,
                DepartamentoId = dto.DepartamentoId,
                Direccion_A = dto.Direccion_A,
                Direccion_B = dto.Direccion_B,
                Direccion_Compuesta = dto.Direccion_Tipo_A + " " + dto.Direccion_A + " " + dto.Direccion_Tipo_B + " " + dto.Direccion_B + " " + dto.Direccion_Observacion,
                Direccion_Observacion = dto.Direccion_Observacion,
                Direccion_Tipo_A = dto.Direccion_Tipo_A,
                Direccion_Tipo_B = dto.Direccion_Tipo_B,
                PaisId = dto.PaisId,
                Telefono = dto.Telefono,
                Servicio_Domicilio = dto.Servicio_Domicilio,
                ClienteId = dto.ClienteId,
                //Cliente = ClientesMapper.map(dto.Cliente)
            };
        }

        public static List<ClientesDirecciones> map(IEnumerable<ClientesDireccionesEntity> lista)
        {
            if (lista == null)
                return null;
            List<ClientesDirecciones> listaResultante = new List<ClientesDirecciones>();
            foreach (var item in lista)
            {
                var dto = map(item);
                listaResultante.Add(dto);
            }
            return listaResultante;
        }

        public static List<ClientesDireccionesEntity> map(IEnumerable<ClientesDirecciones> lista)
        {
            if (lista == null)
                return null;
            List<ClientesDireccionesEntity> listaResultante = new List<ClientesDireccionesEntity>();
            foreach (var item in lista)
            {
                var dto = map(item);
                listaResultante.Add(dto);
            }
            return listaResultante;
        }
    }
}
