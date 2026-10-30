# Guía de entrega de actividades con Visual Studio Code

**Estructura de Datos · INF-3 AE026 · TecNM Monclova**  
**Docente: M.C. Jesús Alejandro Ramos Nolazco**  
Repositorio de la clase: <https://github.com/jarn-tecnm/2026-estructuradedatos>

¿Utilizas Visual Studio? Consulta [la guía para Visual Studio](GUIA_VisualStudio.md).

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

Instala lo siguiente:

| Herramienta | Uso |
| --- | --- |
| [Visual Studio Code](https://code.visualstudio.com/) | Editar el código y trabajar con Git. |
| [Git](https://git-scm.com/downloads) | Clonar, confirmar, enviar y descargar cambios. |
| [SDK de .NET 10](https://dotnet.microsoft.com/download/dotnet/10.0) | Crear, compilar y ejecutar proyectos. Instala el **SDK**, no únicamente el Runtime. |
| Cuenta personal de [GitHub](https://github.com/) | Crear el fork y los pull requests. |

En VS Code abre **Extensions / Extensiones** (`Ctrl+Shift+X`) e instala **C# Dev Kit**, de Microsoft, para obtener herramientas de C#. El soporte básico de Git ya viene integrado en VS Code, pero requiere que Git esté instalado. La extensión **GitHub Pull Requests**, de GitHub, es opcional: esta guía crea los pull requests en el navegador. No necesitas Code Runner, GitLens ni Copilot para seguir los pasos.

Reinicia VS Code después de instalar Git o .NET. Abre **Terminal → New Terminal / Nueva terminal** y comprueba:

```powershell
git --version
dotnet --list-sdks
```

Debe aparecer un SDK `10.0.xxx` si usarás .NET 10. Los nombres de botones pueden variar ligeramente según el idioma y la versión del editor.

## 4. Crear tu fork en GitHub — solo una vez

1. Inicia sesión en GitHub con tu propia cuenta.
2. Entra al [repositorio de la clase](https://github.com/jarn-tecnm/2026-estructuradedatos).
3. Comprueba que ya exista tu carpeta. Si falta, avisa al docente y espera a que la publique.
4. Pulsa **Fork → Create a new fork**.
5. En **Owner**, selecciona tu cuenta. Conserva el nombre `2026-estructuradedatos` y pulsa **Create fork**.
6. Confirma que la dirección sea `https://github.com/TU_USUARIO/2026-estructuradedatos` y que indique que es un fork de `jarn-tecnm/2026-estructuradedatos`.
7. Dentro de **tu fork**, pulsa **Code → Local → HTTPS** y copia la URL.

No crees un repositorio vacío independiente: debe ser un fork del repositorio de la clase. No necesitas un fork nuevo por tarea.

## 5. Clonar tu fork en VS Code — solo una vez por computadora

### Con los botones

1. En la pantalla de bienvenida pulsa **Clone Git Repository… / Clonar repositorio de Git…**. También puedes usar `Ctrl+Shift+P` y ejecutar **Git: Clone**.
2. Pega la URL de **tu fork**, no la del docente.
3. Selecciona una carpeta local donde guardar el repositorio.
4. Al terminar, pulsa **Open / Abrir**. Revisa el contenido antes de conceder confianza al espacio de trabajo.
5. Abre la raíz `2026-estructuradedatos`: allí deben estar el `.gitignore`, el README general y las carpetas de alumnos. No uses **Initialize Repository** ni **Publish to GitHub** para este proyecto ya clonado.

### Alternativa por consola

En una terminal situada en el directorio donde guardarás tus proyectos, reemplaza `TU_USUARIO` y ejecuta:

```powershell
git clone https://github.com/TU_USUARIO/2026-estructuradedatos.git
cd 2026-estructuradedatos
code .
```

Si `code` no se reconoce, abre VS Code y utiliza **File → Open Folder / Archivo → Abrir carpeta**.

Desde la raíz del repositorio comprueba:

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

Puedes utilizar el correo privado `noreply` que GitHub muestra en **Settings → Emails**. Estos datos identifican los commits; no inician sesión. Cuando el editor solicite autenticación, usa la cuenta propietaria de tu fork.

## 6. Crear o copiar la actividad dentro de tu carpeta

En los ejemplos siguientes, **`TuCarpeta` es un marcador**: reemplázalo por el nombre exacto de tu carpeta. Ejecuta los comandos desde la raíz local `2026-estructuradedatos`.

### Opción A: crear un proyecto nuevo

Ejemplo para una actividad llamada `Tarea1_PilasConArreglos`:

```powershell
dotnet new console --framework net10.0 --name PilasConArreglos --output "TuCarpeta/Tarea1_PilasConArreglos"
```

En **Explorer / Explorador**, expande tu carpeta, abre la actividad y edita `Program.cs`. Puedes agregar otras clases `.cs` cuando la práctica lo requiera. Si la carpeta ya contiene un proyecto, no ejecutes de nuevo la creación encima de él.

### Opción B: incorporar un proyecto existente

1. En **Explorer**, selecciona tu carpeta y pulsa **New Folder / Nueva carpeta** para crear `Tarea1_NombreDeLaActividad` con el nombre correcto.
2. Desde el Explorador de archivos de Windows, copia dentro los archivos del proyecto existente: `.csproj`, `.cs`, subcarpetas de código y datos necesarios. Incluye `.sln` o `.slnx` si la solución forma parte de la entrega.
3. No copies la carpeta oculta `.git` de otro repositorio. Tampoco copies `bin`, `obj` ni `.vs`. No ejecutes `git init` dentro de la actividad.
4. Si necesitas archivos `.txt`, `.csv`, `.json` u otros recursos para ejecutar el programa, inclúyelos y evita rutas absolutas como `C:\Users\...`.

La estructura esperada es, por ejemplo:

| Ruta | Contenido |
| --- | --- |
| `TuCarpeta/README.md` | Esta guía. |
| `TuCarpeta/GUIA_VisualStudio.md` | Guía alternativa. |
| `TuCarpeta/Tarea1_PilasConArreglos/PilasConArreglos.csproj` | Configuración del proyecto. |
| `TuCarpeta/Tarea1_PilasConArreglos/Program.cs` | Código de la práctica. |
| `TuCarpeta/Tarea1_PilasConArreglos/Nodo.cs` | Otra clase, si se necesita. |

## 7. Compilar y ejecutar antes de entregar

Guarda los archivos con **File → Save All / Archivo → Guardar todo**. Desde la terminal integrada, en la raíz del repositorio:

```powershell
dotnet build "TuCarpeta/Tarea1_PilasConArreglos/PilasConArreglos.csproj"
dotnet run --project "TuCarpeta/Tarea1_PilasConArreglos/PilasConArreglos.csproj"
```

Sustituye las rutas si tu proyecto tiene otro nombre. El programa se ejecuta en esa terminal y allí puedes escribir las entradas que solicite. `Ctrl+C` permite detenerlo. Si utiliza archivos con rutas relativas, documenta desde qué carpeta debe ejecutarse; puedes abrir una terminal en la carpeta de la actividad y utilizar `dotnet run`.

Las carpetas `bin` y `obj` se regeneran al compilar. El `.gitignore` de la clase ya las excluye; no lo cambies para incluirlas. Antes de entregar verifica que no haya errores de compilación y prueba las opciones principales de tu programa.

## 8. Registrar y subir los cambios a tu fork

### Con los botones de VS Code

1. Abre **Source Control / Control de código fuente**, icono de ramificaciones en la barra izquierda (`Ctrl+Shift+G`). Si hay varios repositorios abiertos, selecciona el de la clase.
2. En **Changes / Cambios**, abre cada archivo y revisa la comparación. Solo deben aparecer cambios tuyos dentro de tu carpeta.
3. Usa el botón **+ / Stage Changes** en los archivos que entregarás. Quedarán en **Staged Changes / Cambios preparados**. Si te equivocas al seleccionar, **− / Unstage Changes** retira la selección sin borrar tu trabajo.
4. Escribe un mensaje claro, por ejemplo: `Agrega Tarea1 PilasConArreglos - Tu nombre`.
5. Pulsa **Commit / Confirmar**. Esto registra los cambios localmente.
6. En **… / More Actions**, selecciona **Push / Enviar**. También puedes usar `Ctrl+Shift+P` y **Git: Push**. Esto sube los commits a tu fork.
7. Abre tu fork en GitHub y verifica que los archivos estén dentro de tu carpeta y que el código corresponda a la última versión.

**Sync Changes / Sincronizar cambios** normalmente hace Pull y luego Push con tu fork. No reemplaza el pull request ni trae por sí solo cambios de la clase. Para este primer envío usa Push y sigue la sección siguiente.

### Alternativa por consola

Desde la raíz del repositorio, después de guardar y revisar:

```powershell
git status
git diff -- "TuCarpeta/"
git add -- "TuCarpeta/Tarea1_PilasConArreglos/"
git diff --cached --name-only
git diff --cached
git commit -m "Agrega Tarea1 PilasConArreglos - Tu nombre"
git push origin main
```

`git diff` no muestra el contenido de archivos nuevos aún no preparados: revísalos en el editor y, después de `git add`, con `git diff --cached`. La lista de archivos preparados debe contener únicamente tu entrega. No uses `git add .` sin comprobar todo lo que incluiría.

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

### Método sencillo: GitHub y después VS Code

1. Termina, guarda y confirma los cambios locales que quieras conservar. Sube a tu fork los commits pendientes. Procura actualizar cuando no tengas una entrega abierta que deba revisarse por separado.
2. En GitHub abre **tu fork**, selecciona `main` y pulsa **Sync fork → Update branch**. Si informa que está actualizado, no hay nada que incorporar allí.
3. En VS Code confirma que estás en `main`. En **Source Control → …**, pulsa **Pull / Extraer**, o ejecuta **Git: Pull** desde `Ctrl+Shift+P`.
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
| No tienes permiso para hacer Push | `origin` debe ser tu fork y la autenticación debe corresponder a tu cuenta. Revisa **Accounts / Cuentas** en VS Code. Git también puede conservar otras credenciales en Windows. |
| Git solicita nombre o correo | Configura `git config user.name` y `git config user.email` como se explicó. |
| `dotnet` o `git` no se reconoce | Verifica la instalación y reinicia VS Code y la terminal. |
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

- [C# en VS Code y C# Dev Kit](https://code.visualstudio.com/docs/languages/csharp).
- [Clonar y gestionar repositorios en VS Code](https://code.visualstudio.com/docs/sourcecontrol/repos-remotes).
- [Preparar cambios y crear commits en VS Code](https://code.visualstudio.com/docs/sourcecontrol/staging-commits).
- [Trabajar con GitHub desde VS Code](https://code.visualstudio.com/docs/sourcecontrol/github).
- [Crear un pull request desde un fork](https://docs.github.com/en/pull-requests/how-tos/create-pull-requests/creating-a-pull-request-from-a-fork).
- [Sincronizar un fork](https://docs.github.com/en/pull-requests/how-tos/work-with-forks/syncing-a-fork).
