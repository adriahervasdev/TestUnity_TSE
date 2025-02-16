Buenas! en este repositorio os he dejado la “Prueba de Concepto y Habilidades en
Unity”. En principio están implementadas todas las funcionalidades descritas en el pdf. A continuación resumiré brevemente como he implementado cada punto para facilitaros la revisión.

Si tenéis alguna duda o queréis comentarme algo sobre la prueba no dudéis en poneros en contacto conmigo. 

# 1. Configuración del Proyecto

Para la creación y configuración de proyecto se ha utilizado lo siguiente:

- **Version Unity:** 2019.4.5f1
- **Plataforma de construcción:** Android
- **Lenguaje de programación:** C#
- **Modo de compilación:** IL2CPP
- **Minimum/Target API Level:** Api level 24
- **ARMv7 y ARM64**

---

# 2. Solicitar Permisos de Ubicación

El Script que maneja la solicitud de permisos se encuentra en:

📂 Assets

│── 📂 TestUnity_TSE

│   │── 📂 Scripts

│   │   │── 📂 Managers

│   │   │   │── 📄 LocationPermissionManager

<aside>
☝🏼

Intente implementar la actualización de la UI mediante callbacks pero me di cuenta que la versión que utilizamos no es compatible. Aún así deje la lógica comentada de los callbacks. 

</aside>

Los assets de la escena que se utilizan son LocationPermissionManager que contiene el script de “LocationPermissionManager” y “TextLocationPermission” que es la referencia UI para mostrar el resultado de los permisos.

![alt text](https://github.com/adriahervasdev/TestUnity_TSE/blob/main/ReadmeImages/image.png "image")

---

# 3. Crear una Ventana Personalizada en el Editor

En este caso, los scripts utilizados para esta funcionalidad se encuntran en estás rutas:

📂 Assets

│── 📂 TestUnity_TSE

│   │── 📂 Scripts

│   │   │── 📂 Editor

│   │   │   │── 📄 SceneManagerEditorWindow.cs

│   │   │   │── 📄 SceneManagerScriptableObject.cs

│   │   │   │── 📄 SceneManagerScriptableObject (Instancia)

Para utilizar la ventana para gestionar las escenas simplemente hay que acceder a ‘Window/Scene Manager’ y asignarle el SceneManagerScriptableObject.

![alt text](https://github.com/adriahervasdev/TestUnity_TSE/blob/main/ReadmeImages/image1.png "image")

---

# 4/6. Generar un Cubo en la Escena mediante un Botón en el Editor / Tareas Adicionales

En este caso, los scripts utilizados para esta funcionalidad se encuentran en estás rutas:

📂 Assets

│── 📂 TestUnity_TSE

│   │── 📂 Scripts

│   │   │── 📂 Editor

│   │   │   │── 📄 CubeSpawnerEditor.cs         //Editor Script 

│   │   │── 📂 Managers

│   │   │   │── 📄 CubeSpawnerManager.cs    //Script manejo de cubos

│   │   │── 📂 Utilities

│   │   │   │── 📄 IntanceChangeMaterial.cs     //Instanciar un objeto con material aleatorio

│   │── 📂 Prefabs

│   │   │── ♟️ BasicCube    //Cubo básico

│   │   │── ♟️ RandomMaterialCube    //Basic cube con IntanceChangeMaterial asignado

Para utilizar manejador de cubos solo hay que utilizar el CubeSpawner de la escena que esta dentro de Managers.
 

![alt text](https://github.com/adriahervasdev/TestUnity_TSE/blob/main/ReadmeImages/image2.png "image")

![alt text](https://github.com/adriahervasdev/TestUnity_TSE/blob/main/ReadmeImages/image3.png "image")
