# mvvmcross-6-beta-net-standard-ios-android-uwp
Código de ejemplo de la charla del día 21/03/2018

<h1>Tutorial de como crear una aplicación con Xamarin Classic para IOS , Android y UWP usando las vistas nativas.</h1>

<p>En este tutorial vamos a crear un proyecto desde 0 para UWP, IOS y Android usando MvvmCross 6 beta, que hace uso de Net Standard.</p>

<p>Como vamos a crear para UWP, lo haremos desde Windows y Visual Studio 2017, en mi caso estoy usando la última* versión la 15.6.0 </p>


<p><strong>Observación:</strong></p>
<p>Xamarin Classic (native) es más complejo que Xamarin Forms, requiere tener conocimiento sobre todas las plataformas, explicaremos de la forma más detallada posible.</p>



<h1>¡Empezamos!</h1>

<h2>Paso 1: Crear una solución vacía:</h2>

<p>Abrimos visual studio 2017, en el menú superior seleccionamos => Nuevo => Proyecto. </p>

<p>Elegimos la opción “Otros tipos de proyectos”, y creamos un proyecto solución en blanco. </p>


<img src="/Img/1.PNG"/> 

<h2>Paso 2: Agregar los proyectos para las plataformas y uno para el Core</h2>

<p> Seleccionamos con el 2º botón la solución vacía y elegimos, <strong>agregar</strong> => <strong>nuevo proyecto.</strong> </p>

<img src="/Img/2.png"/> 

<p>Debemos agregar 4 proyectos: </p>
<ul>
	<li>Core</li>
	<li>Android</li>
	<li>IOS</li>
	<li>UWP</li>
</ul>

	
<p>*Todos los proyectos de plataforma deben tener el proyecto de Core como referencia.</p>

<h3>Agregando el proyecto de Core:</h3>


<img src="/Img/3.PNG"/> 

<h3>Agregando el proyecto de IOS:</h3>

<img src="/Img/4.PNG"/> 

<h3>Agregando el proyecto de Android:</h3>

<img src="/Img/5.PNG"/> 

<h3>Agregando el proyecto de UWP:</h3>

<img src="/Img/6.PNG"/> 


<p>No todas las versiones de UWP son compatible con Net Standard, se debe tener como mínimo la versión “Fall Creators”.</p>

<img src="/Img/7.PNG"/> 
<p>Se puede ver más detalles aquí: <a href="https://blogs.msdn.microsoft.com/dotnet/2017/10/10/announcing-uwp-support-for-net-standard-2-0/">enlace a microsoft</a></p>


<p>Una vez creado todos los proyectos debemos agregar la referencia al proyecto de Core, para esto tenemos que seleccionar con el 2º botón sobre referencia, en el menú que se muestra elegir la opción “<strong>agregar referencia</strong>”, dentro de solución se debe seleccionar el proyecto <strong>Classic.Core</strong> y hacer clic en el botón <strong>aceptar</strong>.</p>

<img src="/Img/8.PNG"/> 

<p>Debemos realizar la misma operación para Android y IOS. El resultado final debe ser similar a este:</p>

<img src="/Img/9.PNG"/> 

<h2>Paso 3: Agregar MvvmCross 6.0.5 (beta)</h2>

<p>Al ser una versión de beta, el paquete que configura casi todo de forma automática no existe en nuget. Vamos a tener que configurar de forma manual.</p>

<p>Pero de cara a futuro, revise si el paquete MvvmCross.StarterPack se encuentra disponible para la versión 6. </p>

<img src="/Img/10.PNG"/>

<p>Para instalar MvvmCross debemos seleccionar la solución con el 2º botón y elegir la opción “administrar paquetes de nuget para la solución”, el siguiente paso es buscar por MvvmCross con la opción “incluir versión preliminar” habilitada. </p>


<img src="/Img/11.PNG"/>

<p>Una vez elegido la versión de MvvmCross 6.0.5, debemos indicar que queremos instalar en todos los proyectos de nuestra solución. El último paso es hacer clic en instalar. </p>

<img src="/Img/12.PNG"/>

<p>Aceptamos y toca esperar que finalice la instalación.</p>



<h2>Paso 4: Configurar MvvmCross en Core</h2>


<p>Antes de empezar a configurar debemos crear las siguientes carpetas dentro del proyecto Core:</p>
<ul>
<li>Constants</li>
<li>Converters
<ul>
<li>Json</li>
</ul>
</li>
<li>Models
<ul>
<li>Base</li>
<li>Movie</li>
</ul>
</li>
<li>Services
<ul>
<li>Connectores</li>
<li>WebServices</li>
</ul>
</li>
<li>ViewModels
<ul>
<li>Base</li>
</ul>
</li>
</ul>

<h3>Paso 4.1 Agregar paquetes nuget</h3>

<p>Nuestra aplicación usará la Api de Themoviedb para esto es necesario crear una cuenta en esta página: https://www.themoviedb.org y obtener la key para consumir datos de la API.</p>

<p>El siguiente paso es instalar el paquete Newtosoft.Json en el proyecto Core que será el responsable de deserializar el json del servicio.</p>

<img src="/Img/13.PNG"/>

<p>El último paquete que vamos a instalar en el proyecto de Core, solo tiene sentido si vamos a dar soporte a versiones inferior a 5 de Android, sirve para trabajar con el httpClient nativo de cada plataforma mejorando los tiempos de respuesta. *Se puede hacer lo mismo configurando el httpClient desde el proyecto de plataforma.</p>

<p>ModernhttpClient , se debe instalar en todos los proyectos. </p>

<img src="/Img/14.PNG"/>


<h3>Paso 4.2 : Agregar el archivo de configuración</h3>

<p>Dentro de la carpeta Constants, vamos a crear una clase con el siguiente nombre ConfigConstants. Usaremos este archivo para guardar la configuración de la aplicación, se puede ver el código aquí: </p>

<p><a target="_blank" href="https://raw.githubusercontent.com/elbrinner/mvvmcross-6-beta-net-standard-ios-android-uwp/master/Classic/Classic.Core/Constants/ConfigConstants.cs">[Código]</a></p>

<h3> 4.3: Crear los modelos</h3>

<p>Vamos a crear 3 modelos:</p>

<ul>
	<li>BaseResponse: Nos ayudará a comunicar si la petición al servicio salió bien o no.</li>
<li>	MoviResponse y ResultMovie: El resultado de las últimas películas de la API. Para agilizar el proceso, copie la respuesta del JSON en esta página: http://json2csharp.com , ella genera todas las propiedades de forma automática. </li>


<p><a target="_blank" href="https://raw.githubusercontent.com/elbrinner/mvvmcross-6-beta-net-standard-ios-android-uwp/master/Img/servicios.json">[Json del servicio]</a></p>

<p><a target="_blank" href="https://raw.githubusercontent.com/elbrinner/mvvmcross-6-beta-net-standard-ios-android-uwp/master/Classic/Classic.Core/Models/Base/BaseResponse.cs" target="_black">[Código BaseResponse]</a></p>

<p><a target="_blank"  href="https://raw.githubusercontent.com/elbrinner/mvvmcross-6-beta-net-standard-ios-android-uwp/master/Classic/Classic.Core/Models/Movie/MovieResponse.cs">[Código MoviResponse]</a></p>
<p><a target="_blank"  href="https://github.com/elbrinner/mvvmcross-6-beta-net-standard-ios-android-uwp/blob/master/Classic/Classic.Core/Models/Movie/ResultMovie.cs">[Código ResultMovie]</a></p>

<h3>Paso 4.4: Crear los Servicios</h3>

<p>Vamos a crear una interface para registrar el conector httpclient de la forma más simples posible.</p>

<p><a target="_blank"  href="https://raw.githubusercontent.com/elbrinner/mvvmcross-6-beta-net-standard-ios-android-uwp/master/Classic/Classic.Core/Services/Connectors/IWebClientService.cs">[Código de la interfaz]</a></p>

<p><a target="_blank"  href="https://raw.githubusercontent.com/elbrinner/mvvmcross-6-beta-net-standard-ios-android-uwp/master/Classic/Classic.Core/Services/Connectors/WebClientService.cs">[Código de la implementación]]</a></p>


<p>Creamos una nueva interfaz para agregar todos los servicios de la API de Themoviedb.</p>

<p><a  target="_blank"  href="https://raw.githubusercontent.com/elbrinner/mvvmcross-6-beta-net-standard-ios-android-uwp/master/Classic/Classic.Core/Services/WebServices/IMovieWebService.cs">[Código de la interfaz]</a></p>
<p><a  target="_blank"  href="https://raw.githubusercontent.com/elbrinner/mvvmcross-6-beta-net-standard-ios-android-uwp/master/Classic/Classic.Core/Services/WebServices/MovieWebService.cs">[Código de la implementación]</a></p>



En breve explicaré como usar.


<h3>Paso 4.5: Crear los ViewModels</h3>

<p>Dentro de la carpeta ViewModels => Base, vamos a crear el archivo BaseViewModel. Todas las propiedades comunes de los viewmodels van en este archivo.</p>


<p><a  target="_blank"  href="https://raw.githubusercontent.com/elbrinner/mvvmcross-6-beta-net-standard-ios-android-uwp/master/Classic/Classic.Core/ViewModels/Base/BaseViewModel.cs">[Código aquí]</a></p>

<p>En BaseViewModel podemos destacar 3 elementos: </p>

<ul>
<li>Se herenda de MvxViewModel&lt;object&gt;</li>
<li>Los servicios se inicializa por el constructor</li>
<li>Contiene 2 propiedades
<ul>
<li>IsBusy para indicar la carga</li>
<li>Title para pintar el titulo de la pantalla.</li>
</ul>
</li>
</ul>


<p>En la carpeta ViewModels, vamos agregar nuestra p&aacute;gina principal: HomeViewModel</p>
<p>En este archivo podemos destacar:</p>
<ul>
<li>Herenda de BaseViewModel</li>
<li>Al cargar la p&aacute;gina (ViewAppeared), se llama el servicio y el resultado se agrega en una propiedad publica que notifica la vista.</li>
</ul>
<p><a  target="_blank" href="https://raw.githubusercontent.com/elbrinner/mvvmcross-6-beta-net-standard-ios-android-uwp/master/Classic/Classic.Core/ViewModels/HomeViewModel.cs">[Código aquí]</a></p>
<p>&nbsp;</p>

<h3>Paso 4.6: Agregar el arranque de la aplicación</h3>

<p>Debemos crear el archivo App.cs, este archivo es el responsable por arrancar la aplicación en el viewmodel indicado, aparte de registrar los servicios.</p>

<p>Todos los servicios terminados por service, se registra de forma automática por MvvmCross. Este es el caso de nuestros 2 servicios (IWebClientService y IMovieWebService). </p>

<p><a  target="_blank" href="https://raw.githubusercontent.com/elbrinner/mvvmcross-6-beta-net-standard-ios-android-uwp/master/Classic/Classic.Core/App.cs">[Código aquí]</a></p>


<h2>Paso 5: Configurar UWP</h2>

<p>Lo primero que debemos crear es un archivo Setup.cs dentro del proyecto Classic.UWP</p>

<p><a  target="_blank" href="https://raw.githubusercontent.com/elbrinner/mvvmcross-6-beta-net-standard-ios-android-uwp/master/Classic/Classic.UWP/Setup.cs">[Código aquí]</a></p>

<p>Este archivo es el responsable por arrancar MvvmCross. </p>

<p>El siguiente paso es eliminar el archivo MainPage.Xaml, debemos crear páginas que herende directamente de MvvmCross.</p>

<p>El próximo para es una carpeta con el nombre de Views, agregaremos nuestras páginas en esta carpeta.</p>

<p>Modificar el archivo App.xaml.cs, debemos agregar la configuración de MvvmCross para controla la navegación.</p>

<p><a  target="_blank" href="https://raw.githubusercontent.com/elbrinner/mvvmcross-6-beta-net-standard-ios-android-uwp/master/Classic/Classic.UWP/App.xaml.cs">[Código aquí]</a></p>

<p>Haga clic con el 2º botón sobre la carpeta Views, elija agregar nuevo elemento. Tenemos que crear una página vacía.</p>

<img src="/Img/20.PNG"/>

<p>Una vez creado debemos agregar modificar la herencia del fichero, las páginas que usan MvvmCross debe heredar de <strong>views:MvxWindowsPage</strong></p>

<img src="/Img/21.PNG"/>


<p><a  target="_blank" href="https://raw.githubusercontent.com/elbrinner/mvvmcross-6-beta-net-standard-ios-android-uwp/master/Classic/Classic.UWP/Views/HomeView.xaml">[Código aquí Xaml]</a></p>

<p><a  target="_blank" href="https://raw.githubusercontent.com/elbrinner/mvvmcross-6-beta-net-standard-ios-android-uwp/master/Classic/Classic.UWP/Views/HomeView.xaml">[Código aquí Xaml]</a></p>

<p><a  target="_blank" href="https://raw.githubusercontent.com/elbrinner/mvvmcross-6-beta-net-standard-ios-android-uwp/master/Classic/Classic.UWP/Views/HomeView.xaml">[Código aquí .CS]</a></p>

<p>Para usar el cargando, debemos crear un converte que indique cuando mostrar o ocultar el <strong>ProgressBar</strong></p>

<p><a  target="_blank" href="https://raw.githubusercontent.com/elbrinner/mvvmcross-6-beta-net-standard-ios-android-uwp/master/Classic/Classic.UWP/Converters/BooleanToVisibilityConverter.cs">[Código aquí .CS]</a></p>

<p> El último paso será crear la vista AboutView, los pasos a seguir son los mismos que para la vista HomeView</p>

<p><a  target="_blank" href="https://raw.githubusercontent.com/elbrinner/mvvmcross-6-beta-net-standard-ios-android-uwp/master/Classic/Classic.UWP/Views/AboutView.xaml">[Código aquí Xaml]</a></p>

<p><a  target="_blank" href="https://raw.githubusercontent.com/elbrinner/mvvmcross-6-beta-net-standard-ios-android-uwp/master/Classic/Classic.UWP/Views/AboutView.xaml.cs">[Código aquí .CS]</a></p>


<h2>Paso 5: Configurar Android</h2>

<h2>Paso 6: Configurar iOS</h2>

<p>Abrimos el AppDelegate, este es el punto de partida de la Aplicación en iOS, aqui controlamos el ciclo de vida de la Aplicación, el proposito es trabajar sin los famosos Storyboards y hacer una aplicacion mas escalable y con un mejor control del flujo</p>

<img src="/Img/ImgAppDelegate.png"/> 

<h2>Paso 2: Agregar las vistas que pintarán los datos segun el modelo de datos</h2>

<p>En este paso creamos dos vistas como patron de diseño Master - Detail, para poder realizar las vista controladores debemos crear seleccionar un nuevo archivo en la carpeta en donde estarán todas nuestras vistas(Views), en la seleccion de el tipo de interfaz que necesitamos buscamos una Vista controlador, esta clase nos creará tanto el .XIB como su relación, para más adelante poder tener acceso a las distintas instancias de los objetos declarados.</p>

<img src="/Img/ImgNuevoArchivo.png"/> 

<img src="/Img/ImgSeleccionVC.png"/> 


















