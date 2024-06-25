import requests
import pandas as pd
import os

token = ""
api_url = "http://localhost:5253/api/Producto"

def get_all():
    headers = {"Authorization": f"Bearer {token}"}
    response = requests.get(f"{api_url}/GetAll", headers=headers)
    data = response.json()["respuesta"]
    df = pd.DataFrame(data)
    return df

def buscar(codigo):
    headers = {"Authorization": f"Bearer {token}"}
    response = requests.get(f"{api_url}/GetAll/{codigo}", headers=headers)
    data = response.json()["respuesta"]
    
    if not data:
        print("Producto no encontrado.")
        return
    
    df = pd.DataFrame(data)
    print(df)

def guardar_producto(datos):
    headers = {
        "Authorization": f"Bearer {token}",
        "Content-Type": "application/json"
    }
    
    url = f"{api_url}/GuardarInfoProducto"
    response = requests.post(url, headers=headers, json=datos)
    
    if response.status_code == 200:
        print(response.json()["response"])
    else:
        print("Error al guardar el producto.")

def modificar_producto(datos):
    headers = {
        "Authorization": f"Bearer {token}",
        "Content-Type": "application/json"
    }
    
    url = f"{api_url}/ModificarInfoProducto"
    response = requests.put(url, headers=headers, json=datos)
    
    if response.status_code == 200:
        print(response.json()["response"])
    else:
        print("Error al modificar el producto.")

def borrar_producto(id_producto):
    headers = {"Authorization": f"Bearer {token}"}
    url = f"{api_url}/BorrarInfoProducto/{id_producto}"
    response = requests.delete(url, headers=headers)
    
    if response.status_code == 200:
        print(response.json()["response"])
    else:
        print("Error al borrar el producto.")

def mostrar_menu():
    print()
    print("**********Menu***************")
    print("1. GetAll")
    print("2. Buscar")
    print("3. Guardar Producto")
    print("4. Modificar Producto")
    print("5. Borrar Producto")
    print("6. Salir")
    print("*****************************")
    print()

def main():
    while True:
        mostrar_menu()
        opcion = input("Selecciona una opción: ")

        if opcion == "1":
            df = get_all()
            os.system('cls')
            print("     -Get All-     ")
            print()
            print(df)
        elif opcion == "2":
            os.system('cls')
            print("     -Buscador-     ")
            print()
            codigo = input("Ingrese el código de barras a buscar: ")
            print()
            buscar(codigo)
        elif opcion == "3":
            try:
                codigo_barras = input("Ingrese el código de barras: ")
                nombre_producto = input("Ingrese el nombre del producto: ")
                stock = int(input("Ingrese el stock del producto: "))
                precio_unitario = float(input("Ingrese el precio unitario del producto: "))
                
                datos_producto = {
                    "codigoBarras": codigo_barras,
                    "nombreProducto": nombre_producto,
                    "stock": stock,
                    "precioUnitario": precio_unitario
                }
                
                guardar_producto(datos_producto)
            except Exception as e:
                print(f"Favor de verificar que los campos se llenaran correctamente")

            
        elif opcion == "4":
            try:
                codigo_barras = input("Ingrese el codigo de barras a modificar: ")
                nombre_producto = input("Ingrese el nuevo nombre del producto: ")
                stock = int(input("Ingrese el nuevo stock del producto: "))
                precio_unitario = float(input("Ingrese el nuevo precio unitario del producto: "))
                
                datos_modificacion = {
                    "codigoBarras": codigo_barras,
                    "nombreProducto": nombre_producto,
                    "stock": stock,
                    "precioUnitario": precio_unitario
                }
                modificar_producto(datos_modificacion)
            except Exception as e:
                print(f"Favor de verificar que los campos se llenaron correctamente")
            
        elif opcion == "5":
            id_producto_borrar = int(input("Ingrese el ID del producto a borrar: "))
            borrar_producto(id_producto_borrar)
        elif opcion == "6":
            print("Saliendo")
            break
        else:
            print("Opción no válida. Por favor, selecciona una opción válida.")

main()

'''
# URL de la API
url = 'http://localhost:5253/api/Autenticacion/Token'
Usuario = input("Ingrese el usuario: ")
Contraseña = input("Ingrese la contraseña: ")
UGuid = input("Ingrese UGUID: ")
# Datos de entrada en formato JSON
data = {
    "usuario": Usuario,
    "contra": Contraseña,
    "uGuid": UGuid
}

response = requests.post(url, json=data)

if response.status_code == 200:
    response_data = response.json()

    token = response_data.get('access_token', '')


else:
    print("Error:", response.status_code)

main()
'''