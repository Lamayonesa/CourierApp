
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiAppMaui.Models;
using MiAppMaui.Services;

namespace MiAppMaui.ViewModels;

public partial class ClienteFormViewModel : ObservableObject
{
    // Expresiones regulares para validar los datos
    private static readonly Regex SoloLetras =
        new(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$");

    private static readonly Regex DiezDigitos =
        new(@"^[0-9]{10}$");

    /*
     * Creación de propiedades con el atributo ObservableProperty.
     *
     * Nota: Los atributos proporcionan metadatos a clases,
     * métodos, propiedades y campos.
     * En C# se representan mediante corchetes [].
     *
     * ObservableProperty genera propiedades públicas
     * que notifican sus cambios a la interfaz.
     */

    [ObservableProperty] private int id;
    [ObservableProperty] private string nombre = string.Empty;
    [ObservableProperty] private string telefono = string.Empty;
    [ObservableProperty] private string direccion = string.Empty;

    // Error messages (mensajes de error)
    [ObservableProperty] private string nombreError = string.Empty;
    [ObservableProperty] private string telefonoError = string.Empty;
    [ObservableProperty] private string direccionError = string.Empty;

    /*
     * Esto es una propiedad que contiene un objeto
     * de la clase ObservableCollection<string>.
     *
     * Permite almacenar una colección de textos y
     * notificar cuando agregamos o eliminamos elementos.
     *
     * Dato interesante:
     * get permite obtener la colección.
     *
     * Al no tener set, no podemos reemplazar la colección
     * mediante una asignación después de inicializarla.
     *
     * Sin embargo, sí podemos agregar o eliminar elementos
     * utilizando métodos como Add() y Remove().
     */

    public ObservableCollection<string> EstadosDisponibles { get; }
        = new() { "Activo", "Inactivo" };

    // Mostramos la misma colección que utiliza el servicio de memoria.
    public ObservableCollection<Cliente> Clientes => MemoriaService.Clientes;

    // Método para guardar los clientes
    [RelayCommand]
    private async Task GuardarAsync()
    {
        // Verificamos si los datos son correctos
        if (!Validar()) return;

        // Creación de un objeto de la clase Cliente
        var cliente = new Cliente
        {
            Nombre = Nombre.Trim(),
            Telefono = Telefono.Trim(),
            Direccion = Direccion.Trim()
        };

        // Agregamos el cliente al servicio de memoria
        MemoriaService.AgregarCliente(cliente);

        // Mostramos un mensaje de confirmación
        await Shell.Current.DisplayAlertAsync(
            "Cliente registrado",
            $"{cliente.Nombre} fue agregado correctamente.",
            "Aceptar");

        // Limpiamos los campos del formulario
        Limpiar();
    }

    // Método general para validar todos los datos
    private bool Validar()
    {
        ValidarNombre();
        ValidarTelefono();
        ValidarDireccion();

        /*
         * IsNullOrEmpty comprueba si una cadena
         * está vacía o es null.
         *
         * All verifica que todos los mensajes
         * de error estén vacíos.
         *
         * Si todos están vacíos devuelve true.
         * Si alguno tiene un error devuelve false.
         */

        return new[]
        {
            NombreError,
            TelefonoError,
            DireccionError

        }.All(string.IsNullOrEmpty);
    }

    // Método para validar el nombre
    private void ValidarNombre()
    {
        if (string.IsNullOrWhiteSpace(Nombre) ||
            Nombre.Trim().Length is < 2 or > 50)
        {
            NombreError =
                "El nombre es obligatorio y debe tener entre 2 y 50 caracteres.";
        }
        else if (!SoloLetras.IsMatch(Nombre.Trim()))
        {
            NombreError =
                "El nombre solo puede contener letras y espacios.";
        }
        else
        {
            NombreError = string.Empty;
        }
    }

    // Método para validar el teléfono
    private void ValidarTelefono()
    {
        TelefonoError = DiezDigitos.IsMatch(Telefono.Trim())
            ? string.Empty
            : "El teléfono debe tener exactamente 10 dígitos.";
    }

    // Método para validar la dirección
    private void ValidarDireccion()
    {
        DireccionError =
            string.IsNullOrWhiteSpace(Direccion) ||
            Direccion.Trim().Length is < 5 or > 200
            ? "La dirección debe tener entre 5 y 200 caracteres."
            : string.Empty;
    }

    // Método para limpiar el formulario
    private void Limpiar()
    {
        // Limpiamos las propiedades del cliente
        Id = 0;
        Nombre = string.Empty;
        Telefono = string.Empty;
        Direccion = string.Empty;

        // Limpiamos los mensajes de error
        NombreError = string.Empty;
        TelefonoError = string.Empty;
        DireccionError = string.Empty;
    }
}
