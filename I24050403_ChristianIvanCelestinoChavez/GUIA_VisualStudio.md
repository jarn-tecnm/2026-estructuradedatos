# Guía de entrega de actividades con Visual Studio

**Estructura de Datos · INF-3 AE026 · TecNM Monclova**  
**Docente: M.C. Jesús Alejandro Ramos Nolazco**  
Repositorio de la clase: <https://github.com/jarn-tecnm/2026-estructuradedatos>

¿Utilizas Visual Studio Code? Consulta [la guía para VS Code](README.md).

## 1. Reglas de entrega

- Trabaja únicamente dentro de la carpeta que te asignó el docente. Respeta su nombre exacto, incluidos matrícula, acentos y mayúsculas si los tiene.
- **No se aceptarán pull requests que modifiquen, agreguen o eliminen archivos dentro de la carpeta de otra persona.** Tampoco modifiques los archivos generales de la clase, como el `.gitignore` o el README de la raíz, salvo indicación expresa.
- Cada actividad debe estar en una subcarpeta con este formato: **`Tarea1_NombreDeLaActividad`**. Sustituye el número y el nombre por los indicados por el docente.
- Si aún desconoces el número, utiliza **`TareaN_NombreDeLaActividad`**, con la letra `N` literal. Cuando el docente lo indique, corrige el nombre antes de la entrega definitiva.
- Ejemplo ilustrativo: `Tarea1_PilasConArreglos`. No uses ese título si el docente indicó otro.
- Entrega el proyecto completo: `.csproj`, archivos `.cs` y los datos necesarios para ejecutarlo. Un ejecutable o una captura no sustituyen el código.
- Usa preferentemente .NET 10; si necesitas otra versión, consúltalo con el docente. No cambies los proyectos de tus compañeros.
- No entregues el proyecto solamente en ZIP. Los archivos deben poder revisarse directamente en GitHub.
- Conserva estas guías. No es necesario modificarlas para entregar una tarea.

> El repositorio es público. Evita incluir contraseñas, tokens o datos personales innecesarios en el código y en las capturas.

## 2. Qué significa cada acción

| Acción | Resultado |
| --- | --- |
| Fork | Crea una copia vinculada al repositorio de la clase, en tu cuenta de GitHub. |
| Clonar | Descarga tu fork a tu computadora con su historial. |
| Guardar | Conserva los cambios del archivo en tu computadora. |
| Stage / Preparar | Selecciona los cambios que incluirás en el siguiente commit. |
| Commit / Confirmar | Registra una versión de los cambios en tu copia local. |
| Push / Enviar | Sube tus commits a tu fork en GitHub. |
| Pull request | Solicita al docente incorporar tus cambios al repositorio de la clase. |
| Pull / Extraer | Descarga e integra cambios del remoto configurado; normalmente, tu propio fork. |

**Guardar, hacer commit y hacer push no equivalen a entregar al repositorio de la clase. Debes abrir el pull request y comprobar su destino.**

## 3. Preparación inicial

Esta guía corresponde a **Visual Studio para Windows**, un programa distinto de Visual Studio Code.

| Herramienta | Requisito |
| --- | --- |
| [Visual Studio Community 2026](https://visualstudio.microsoft.com/vs/community/) o una edición compatible | Para trabajar con proyectos dirigidos a .NET 10, utiliza Visual Studio 2026, versión 18.0 o posterior. Las actualizaciones del SDK pueden requerir una actualización del IDE. |
| Visual Studio Installer | Instala la carga de trabajo **.NET desktop development / Desarrollo de escritorio de .NET** y verifica la disponibilidad del SDK de .NET 10. |
| [Git](https://git-scm.com/downloads) | Visual Studio integra funciones de Git. Instala Git para Windows si el comando `git` no está disponible en la terminal. |
| Cuenta personal de [GitHub](https://github.com/) | Crear el fork y enviar las solicitudes. |

No necesitas una extensión adicional para las operaciones básicas de Git. Los pull requests de esta guía se crean en el navegador; no requieren GitHub CLI ni Copilot. Comprueba tu versión en **Help → About Microsoft Visual Studio / Ayuda → Acerca de Microsoft Visual Studio**. Visual Studio 2022 no ofrece soporte oficial para proyectos dirigidos a `net10.0`; actualiza a Visual Studio 2026 o consulta con el docente si puedes usar otra versión de .NET.

Abre **View → Terminal / Ver → Terminal** y comprueba:

```powershell
git --version
dotnet --list-sdks
```

Debe aparecer un SDK `10.0.xxx` si usarás .NET 10. Si falta, instala el SDK desde el instalador o desde [la página de .NET 10](https://dotnet.microsoft.com/download/dotnet/10.0). Los nombres y la ubicación de algunos botones pueden variar según idioma y versión.

## 4. Crear tu fork en GitHub — solo una vez

1. Inicia sesión en GitHub con tu propia cuenta.
2. Entra al [repositorio de la clase](https://github.com/jarn-tecnm/2026-estructuradedatos).
3. Comprueba que ya exista tu carpeta. Si falta, avisa al docente y espera a que la publique.
4. Pulsa **Fork → Create a new fork**.
5. En **Owner**, selecciona tu cuenta. Conserva el nombre `2026-estructuradedatos` y pulsa **Create fork**.
6. Confirma que la dirección sea `https://github.com/TU_USUARIO/2026-estructuradedatos` y que indique que es un fork de `jarn-tecnm/2026-estructuradedatos`.
7. Dentro de **tu fork**, pulsa **Code → Local → HTTPS** y copia la URL.

No crees un repositorio vacío independiente: debe ser un fork del repositorio de la clase. No necesitas un fork nuevo por tarea.

## 5. Clonar tu fork en Visual Studio — solo una vez por computadora

### Con los botones

1. En la pantalla inicial selecciona **Clone a repository / Clonar un repositorio**. Si ya tienes Visual Studio abierto, utiliza **Git → Clone Repository / Clonar repositorio**.
2. En **Repository location / Ubicación del repositorio** pega la URL HTTPS de **tu fork**, no la del docente.
3. En **Path / Ruta** selecciona dónde guardar la copia local y pulsa **Clone / Clonar**. Si solicita autenticación, inicia sesión con la cuenta propietaria del fork.
4. Si aparece la vista de carpetas, es normal: el repositorio tiene trabajos de varios alumnos y no una única solución compartida.
5. Localiza tu carpeta. Para abrir un proyecto existente, utiliza **File → Open → Project/Solution / Archivo → Abrir → Proyecto o solución** y selecciona su `.csproj`, `.sln` o `.slnx`.
6. Para explorar todo el repositorio puedes utilizar **File → Open → Folder / Archivo → Abrir → Carpeta** y seleccionar la raíz `2026-estructuradedatos`. No crees otro repositorio Git para la actividad.

### Alternativa por consola

Desde el directorio donde guardarás los proyectos, reemplaza `TU_USUARIO`:

```powershell
git clone https://github.com/TU_USUARIO/2026-estructuradedatos.git
cd 2026-estructuradedatos
```

Después abre esa carpeta en Visual Studio. En la terminal situada en la raíz comprueba:

```powershell
git remote -v
git branch --show-current
```

`origin` debe apuntar a **tu cuenta** y la rama será `main`. Esta guía utiliza `main` de tu fork; no necesitas una rama permanente por alumno en el repositorio de la clase.

Configura tu autoría una vez en esta copia local, sustituyendo los ejemplos:

```powershell
git config user.name "Tu nombre completo"
git config user.email "TU_CORREO_VERIFICADO_EN_GITHUB"
```

Puedes usar el correo privado `noreply` que GitHub muestra en **Settings → Emails**. Estos datos identifican al autor, pero no inician sesión. Verifica la cuenta de GitHub en el selector de cuentas de Visual Studio si el envío falla.

## 6. Crear o copiar la actividad dentro de tu carpeta

En los ejemplos, **`TuCarpeta` es un marcador**: sustitúyelo por el nombre exacto de tu carpeta. No cambies los nombres de las carpetas asignadas a los alumnos.

### Opción A: crear un proyecto con el asistente

1. Selecciona **File → New → Project / Archivo → Nuevo → Proyecto**.
2. Busca **Console App / Aplicación de consola**, lenguaje **C#**. Elige la plantilla de .NET moderno; no **Console App (.NET Framework)**.
3. Indica un nombre de proyecto descriptivo; por ejemplo, `PilasConArreglos`.
4. En **Location / Ubicación**, selecciona o escribe la ruta de tu actividad dentro de la copia clonada: `.../2026-estructuradedatos/TuCarpeta/Tarea1_PilasConArreglos`.
5. Si aparecen opciones de solución, puedes marcar **Place solution and project in the same directory / Colocar la solución y el proyecto en el mismo directorio**. La ubicación exacta de los archivos varía con esa opción: comprueba al terminar que **todo el proyecto y la solución estén dentro de la carpeta de la tarea**. Una subcarpeta adicional con el nombre del proyecto es aceptable.
6. Selecciona **.NET 10.0** como framework y pulsa **Create / Crear**. Si no aparece, revisa el SDK y la versión de Visual Studio.
7. No marques opciones para crear un nuevo repositorio Git. La copia de la clase ya tiene uno.

Si el asistente dejó los archivos fuera de la carpeta de actividad, corrige la ubicación antes de hacer commit. No coloques una solución compartida en la raíz del repositorio de la clase.

### Opción B: crear el proyecto desde la terminal

Para obtener una estructura sencilla y predecible, desde la raíz del repositorio ejecuta:

```powershell
dotnet new console --framework net10.0 --name PilasConArreglos --output "TuCarpeta/Tarea1_PilasConArreglos"
```

Después utiliza **File → Open → Project/Solution** para abrir el archivo `PilasConArreglos.csproj`. No vuelvas a ejecutar la creación sobre un proyecto existente.

### Opción C: incorporar un proyecto existente

1. Crea la carpeta `Tarea1_NombreDeLaActividad` dentro de tu carpeta asignada, con el número y nombre indicados por el docente.
2. Copia dentro los archivos `.csproj`, `.cs`, carpetas de código, recursos y, si corresponde, `.sln` o `.slnx`.
3. No copies `.git`, `bin`, `obj` ni `.vs`. No ejecutes `git init` dentro de la tarea.
4. Abre el proyecto copiado en Visual Studio y verifica que las referencias apunten a archivos incluidos en la entrega, no al proyecto original fuera del repositorio.
5. Incluye los datos `.txt`, `.csv`, `.json` u otros que necesite el programa y evita rutas absolutas de tu computadora.

Ejemplo de estructura:

| Ruta | Contenido |
| --- | --- |
| `TuCarpeta/README.md` | Guía para VS Code. |
| `TuCarpeta/GUIA_VisualStudio.md` | Esta guía. |
| `TuCarpeta/Tarea1_PilasConArreglos/PilasConArreglos.csproj` | Configuración del proyecto. |
| `TuCarpeta/Tarea1_PilasConArreglos/Program.cs` | Código principal. |
| `TuCarpeta/Tarea1_PilasConArreglos/Nodo.cs` | Clase adicional, si se necesita. |

Si Visual Studio creó una subcarpeta de proyecto dentro de la tarea, adapta las rutas de los comandos siguientes.

## 7. Compilar y ejecutar antes de entregar

### Con los botones

1. Guarda con **File → Save All / Archivo → Guardar todo**.
2. Si tienes varios proyectos en una solución, haz clic derecho en el tuyo y selecciona **Set as Startup Project / Establecer como proyecto de inicio**.
3. Selecciona **Build → Build Solution / Compilar → Compilar solución** (`Ctrl+Shift+B`) y corrige los errores.
4. Ejecuta con **Debug → Start Without Debugging / Depurar → Iniciar sin depurar** (`Ctrl+F5`). Para depurar con puntos de interrupción utiliza **Start / Iniciar** (`F5`).
5. Escribe las entradas en la consola que se abra. Visual Studio normalmente ejecuta el programa en una ventana de consola; si quieres usar la terminal integrada, utiliza los comandos siguientes.

### Por consola

Abre **View → Terminal / Ver → Terminal**, sitúate en la raíz local `2026-estructuradedatos` y ejecuta:

```powershell
dotnet build "TuCarpeta/Tarea1_PilasConArreglos/PilasConArreglos.csproj"
dotnet run --project "TuCarpeta/Tarea1_PilasConArreglos/PilasConArreglos.csproj"
```

Sustituye las rutas por las de tu proyecto. Para detenerlo puedes usar `Ctrl+C`. Si utiliza archivos relativos al directorio de ejecución, documenta la carpeta desde la que debe iniciarse; también puedes situarte en la carpeta del `.csproj` y ejecutar `dotnet run`.

Las carpetas `bin`, `obj` y `.vs` no forman parte de la entrega. El `.gitignore` de la clase ya las excluye. Prueba las opciones principales del programa antes de continuar.

## 8. Registrar y subir los cambios a tu fork

### Con los botones de Visual Studio

1. Abre **View → Git Changes / Ver → Cambios de Git**. También puedes buscar **Git Changes** mediante `Ctrl+Q`.
2. Comprueba el repositorio activo y la rama `main`, especialmente si abriste otros proyectos o repositorios.
3. En **Changes / Cambios**, abre cada archivo para revisar las diferencias. Solo deben existir cambios tuyos dentro de tu carpeta.
4. Pulsa **+ / Stage** junto a los archivos de la entrega. Pasarán a **Staged Changes / Cambios almacenados provisionalmente**. El botón **− / Unstage** retira un archivo de la selección sin borrarlo.
5. Escribe un mensaje como `Agrega Tarea1 PilasConArreglos - Tu nombre` y selecciona **Commit Staged / Confirmar cambios preparados**. La traducción exacta puede variar.
6. Selecciona **Git → Push / Enviar** o el botón **Push**, identificado por una flecha hacia arriba en **Git Changes**. Si dudas del icono, coloca el cursor encima para leer su nombre.
7. En GitHub abre tu fork y comprueba que los archivos y el último código estén presentes.

También existen opciones como **Commit All**, **Commit All and Push** y **Sync**. Para evitar incluir archivos ajenos por accidente, en esta guía se preparan los archivos y se ejecutan Commit y Push por separado. **Sync** hace Pull y Push con el remoto de tu fork; no crea la solicitud al docente ni sincroniza automáticamente con la clase.

### Alternativa por consola

Desde la raíz local del repositorio, después de guardar:

```powershell
git status
git diff -- "TuCarpeta/"
git add -- "TuCarpeta/Tarea1_PilasConArreglos/"
git diff --cached --name-only
git diff --cached
git commit -m "Agrega Tarea1 PilasConArreglos - Tu nombre"
git push origin main
```

`git diff` no muestra archivos nuevos sin preparar: revísalos en el editor y después con `git diff --cached`. No uses `git add .` sin comprobar todo lo que incluiría. Si la actividad tiene una subcarpeta de proyecto, preparar la carpeta completa de la actividad también incluye esos archivos.

## 9. Abrir el pull request hacia la clase

Este paso se realiza en GitHub y no requiere una extensión adicional.

1. Abre el [repositorio de la clase](https://github.com/jarn-tecnm/2026-estructuradedatos).
2. Pulsa **Pull requests → New pull request** y después **compare across forks**. Si aparece **Compare & pull request**, también puedes utilizarlo comprobando los destinos.
3. Selecciona:

   | Campo | Valor |
   | --- | --- |
   | Base repository | `jarn-tecnm/2026-estructuradedatos` |
   | Base | `main` |
   | Head repository / Head fork | `TU_USUARIO/2026-estructuradedatos` |
   | Compare | `main` de tu fork |

4. Revisa la lista de archivos y la comparación completa. Si aparece una modificación fuera de tu carpeta, corrígela antes de continuar.
5. Pulsa **Create pull request**. Usa un título como `Tarea1_PilasConArreglos - Tu nombre`.
6. En la descripción indica tu nombre, carpeta, tarea, versión de .NET, cómo ejecutar y qué comprobaste. Explica cualquier detalle pendiente.
7. Confirma con **Create pull request** y guarda el enlace para acreditar la solicitud.

**El docente decide si se incorpora la entrega. No presiones Merge pull request.** Si GitHub impide crear la solicitud por restricciones de acceso, informa al docente con tu usuario; no crees otro repositorio ni cambies permisos.

### Correcciones y siguientes tareas

- Si el docente solicita correcciones y el pull request sigue abierto, modifica tu código, haz commit y Push a la misma rama `main` de tu fork. **El pull request se actualiza automáticamente**; no abras uno duplicado.
- Mientras ese pull request esté abierto, nuevos commits en esa misma rama también se añadirán a la solicitud. No mezcles otra actividad si el docente pidió revisarlas por separado.
- Cuando la solicitud esté **Merged**, sincroniza tu fork y tu copia local antes de comenzar la siguiente entrega. Repite desde la creación de la actividad; no vuelvas a clonar ni a crear el fork.
- Si está **Closed** sin incorporar, lee el motivo y sigue las indicaciones del docente antes de abrir otra solicitud.

## 10. Descargar cambios de la clase

Actualizar es recomendable antes de cada actividad y después de que acepten tu entrega. Si el docente anuncia instrucciones nuevas, actualiza antes de continuar. Los cambios de otros alumnos en carpetas distintas normalmente no borran tu trabajo, pero tu copia no los tendrá hasta sincronizarla.

### Método sencillo: GitHub y después Visual Studio

1. Termina, guarda y confirma los cambios locales que quieras conservar. Sube a tu fork los commits pendientes. Procura actualizar cuando no tengas una entrega abierta que deba revisarse por separado.
2. En GitHub abre **tu fork**, selecciona `main` y pulsa **Sync fork → Update branch**. Si informa que está actualizado, no hay nada que incorporar allí.
3. En Visual Studio confirma que estás en `main` y selecciona **Git → Pull / Extraer**, o el botón **Pull** de la ventana **Git Changes / Cambios de Git**.
4. Comprueba que aparezcan los nuevos archivos o instrucciones.

El paso 2 actualiza tu copia en GitHub; el paso 3 actualiza tu computadora. Un Pull de `origin` sin haber actualizado el fork no incorpora novedades de la clase.

### Alternativa completa por consola

Desde la raíz del repositorio, registra una sola vez el remoto de la clase:

```powershell
git remote add upstream https://github.com/jarn-tecnm/2026-estructuradedatos.git
git remote -v
```

`origin` debe apuntar a tu fork y `upstream` a la clase. Si `upstream` ya existe, no repitas el comando: comprueba su URL.

Con el trabajo local guardado y confirmado, ejecuta en orden; detente si aparece un error o conflicto:

```powershell
git status
git switch main
git pull --no-rebase origin main
git fetch upstream
git merge --no-edit upstream/main
git push origin main
```

`git status` debe indicar que no hay cambios sin confirmar antes de integrar. Esta alternativa actualiza tu computadora desde la clase y luego sube el resultado a tu fork; no necesitas repetir Sync fork en el navegador. Si se abre un editor para un mensaje de integración, conserva el mensaje, guarda y cierra.

**Si hay conflictos**, no selecciones opciones al azar ni uses `--force`. Revisa los archivos indicados y pide apoyo al docente. La resolución puede afectar el trabajo de ambos lados; no borres archivos de compañeros para que desaparezca el error.

## 11. Problemas frecuentes

| Mensaje o situación | Qué revisar |
| --- | --- |
| No tienes permiso para hacer Push | `origin` debe ser tu fork y la autenticación debe corresponder a tu cuenta. Revisa el selector de cuentas de Visual Studio. Git también puede conservar otras credenciales en Windows. |
| Git solicita nombre o correo | Configura `git config user.name` y `git config user.email` como se explicó. |
| `dotnet` o `git` no se reconoce | Verifica la instalación y reinicia Visual Studio y la terminal. |
| No se encuentra un proyecto para ejecutar | Usa `dotnet run --project` con la ruta de tu `.csproj`. |
| .NET no admite `net10.0` | Comprueba `dotnet --list-sdks` e instala el SDK 10; si hay un `global.json`, revisa la versión que solicita. |
| Push rechazado porque hay cambios remotos | Confirma tu trabajo, descarga con Pull, resuelve los conflictos si existen y vuelve a hacer Push. No fuerces el envío. |
| No aparecen `bin` u `obj` entre los cambios | Es correcto: los excluye el `.gitignore`. |
| El pull request dice que no hay diferencias | Comprueba repositorios, ramas, commit y Push. Si ya fue incorporado, no hay cambios nuevos que entregar. |
| Aparecen archivos de otra carpeta en la propuesta | Detén la entrega y corrige con apoyo si no sabes cómo. No se aceptará así. |
| Tu actividad aparece como repositorio incrustado | Probablemente copiaste un proyecto con su propia carpeta `.git`. Pide apoyo y entrega los archivos de código dentro de la copia de la clase. |

## 12. Comprobación final

- [ ] El número y nombre de la tarea coinciden con la indicación del docente.
- [ ] Todo lo entregado está dentro de mi carpeta.
- [ ] Incluí `.csproj`, `.cs` y los recursos necesarios, sin depender de rutas de mi computadora.
- [ ] El programa compila y funciona con las entradas de prueba.
- [ ] Revisé los archivos preparados antes del commit.
- [ ] Hice Push y verifiqué los archivos en mi fork.
- [ ] Abrí el pull request hacia `jarn-tecnm/2026-estructuradedatos`, rama `main`.
- [ ] Revisé que la propuesta no cambie archivos generales ni carpetas de compañeros.
- [ ] Guardé el enlace y revisaré la respuesta del docente.

## Referencias de consulta

Documentación oficial consultada el 30 de octubre de 2026:

- [Instalar .NET en Windows y compatibilidad con Visual Studio](https://learn.microsoft.com/en-us/dotnet/core/install/windows).
- [Clonar un repositorio en Visual Studio](https://learn.microsoft.com/en-us/visualstudio/version-control/git-clone-repository).
- [Preparar archivos y crear un commit en Visual Studio](https://learn.microsoft.com/en-us/visualstudio/version-control/git-make-commit).
- [Fetch, Pull, Push y Sync en Visual Studio](https://learn.microsoft.com/en-us/visualstudio/version-control/git-fetch-pull-sync).
- [Crear un pull request desde un fork](https://docs.github.com/en/pull-requests/how-tos/create-pull-requests/creating-a-pull-request-from-a-fork).
- [Sincronizar un fork](https://docs.github.com/en/pull-requests/how-tos/work-with-forks/syncing-a-fork).
