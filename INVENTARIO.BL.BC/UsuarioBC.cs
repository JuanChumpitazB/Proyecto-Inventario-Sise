using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using INVENTARIO.BL.BE;
using INVENTARIO.DL.DALC;

namespace INVENTARIO.BL.BC
{
    public class UsuarioBC
    {
        UsuarioDALC usuarioDALC = new UsuarioDALC();
        public bool ValidarLogin(string usuario, string password)
        {
            return usuarioDALC.ValidarLogin(usuario,password);
        }
        public List<UsuarioBE> ListaUsuarios()
        {
            return usuarioDALC.ListaUsuarios();
        }
        public List<UsuarioBE> ListaUsuariosBloqueados()
        {
            return usuarioDALC.ListaUsuariosBloqueados();
        }
        public UsuarioBE BuscarXid(int idUsuario)
        {
            return usuarioDALC.BuscarXid(idUsuario);
        }
        public bool AgregarUsuario(UsuarioBE usuarioBE)
        {
            return usuarioDALC.AgregarUsuario(usuarioBE);
        }
        public bool ActualizarUsuario(UsuarioBE usuarioBE)
        {
            return usuarioDALC.ActualizarUsuario(usuarioBE);
        }
        public bool ExisteUsuario(string usuario)
        {
            return usuarioDALC.ExisteUsuario(usuario);
        }
        public void ActualizarIntenosSumar(string usuario)
        {
            usuarioDALC.ActualizarIntenosSumar(usuario);
        }
        public void ActualizarIntenosCero(string usuario)
        {
            usuarioDALC.ActualizarIntenosCero(usuario);
        }
        public bool ActualizarEstado(string usuario, byte estado)
        {
            return usuarioDALC.ActualizarEstado(usuario,estado);
        }
        public bool NuevoPassword(string usuario, string password, string passwordNuevo)
        {
            return usuarioDALC.NuevoPassword(usuario,password,passwordNuevo);
        }
        public bool ReestablecerPassword(int idUsuario)
        {
            return usuarioDALC.ReestablecerPassword(idUsuario);
        }
        public int VerificarEstado(string usuario)
        {
            return usuarioDALC.VerificarEstado(usuario);
        }
        public int VerificarIntentos(string usuario)
        {
            return usuarioDALC.VerificarIntentos(usuario);
        }
        public int VerificarRol(string usuario)
        {
            return usuarioDALC.VerificarRol(usuario);
        }
        public string VerificarPasswordNuevo(string usuario)
        {
            return usuarioDALC.VerificarPasswordNuevo(usuario);
        }
        public bool Eliminar(int idUsuario)
        {
            return usuarioDALC.Eliminar(idUsuario);
        }
    }
}
