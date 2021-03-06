<img src="//habrastorage.org/files/2c8/65e/77a/2c865e77aa424b4784e04bff4d9bcb4d.jpg"/>
Это статья-заметка о работе с Sandcastle и <abbr title="Sandcastle Help File Builder" >SHFB</abbr>, дабы не забыть самому и рассказать другим.

Со времён последней статьи о Sandcastle (<a href="http://habrahabr.ru/post/102177/">http://habrahabr.ru/post/102177/</a>) прошло 4 года, так что пора освежить некоторые моменты этой утилиты документации.
<habracut/>
Когда встал вопрос о документации на нашем проекте, то выбор стоял по большей части между Doxygen(который уже использовался в проекте), и Sandcastle (который использовался раньше заказчиком). В итоге выбор пал на Sandcastle, т.к. он был рекомендован самим заказчиком, генерировал схожую  визуально документацию, в отличии от Doxygen, а также интеграцией с Help&Manual (интеграция в итоге не использовалась).

Для тех, кому лень гуглить, но интересно посмотреть список других тулзов для документации, вот неплохой список: http://stackoverflow.com/a/14420174

В упрощённом виде задача из себя представляла генерирование документации в виде ".chm" файла и хелпа на сайте. В качестве примера будет небольшой проект, из библиотеки с парой документированных классов и самого Sandcastle проекта (ссылка на гитхаб: https://github.com/misiam/Sandcastle-Sample).

<h4>Install</h4>
Прежде всего нужно инсталлировать Sandcastle, а если точнее то Sandcastle Help File Builder (SHFB) - это продолжение проекта, который злобно брошен фирмой M$ и заботливо форкнут Eric Woodruff. Качаем отсюда: http://shfb.codeplex.com/releases/view/121365 

Мне важны были прежде всего chm-компиллятор и плагин к VS2012 и VS2013. Кроме этого ещё установится собственно сам  Sandcastle Help File Builder - это приложение, которое позволяет пользоваться интерфейсом, а не прописывать всё в xml-файлах. За исключением тулбара с редактированием текста (жирный, курсив и т.п.) я не нашёл отличий между SHFB и плагином к студии, а студия ещё и автокомплит с интелисенсом предлагает, так что разработку я постепенно перевёл на неё. 

<h4>Настройка проекта</h4>
Когда всё установлено, можно добавлять проект в солюшн. В студии в темплейтах появился "Documentation/Sandcastle Help File Builder Project", выбираем его, добавляем "Documentation Sources" (ссылку на проект, который документируем), в проекте включаем "XML documentation file", и запускаем билд. Заходим в папку /bin ... и ничего там не находим. Всё дело в том, что по-умолчанию Sandcastle создаёт файлы в папке \Help  в проектном фолдере.
Чтобы этого избежать, идём в свойства проекта -> Path -> "Help content output path" и меняем на что-нибудь более привычное, например, на "bin\Help\". После билда можно увидеть LastBuild.log (по умолчанию создаётся в output folder) и chm файл. На внешний вид и предупреждения пока не обращайте внимания.
Теперь хелп создаётся в том фолдере, в котором мы хотели, но хелп должен открываться ещё и с вебки, а chm полноценно поддерживает только explorer,  остальные же браузеры в лучшем случае откроют такой хелп с соответствующим плагином. Проще сгенерировать Website:  свойства проекта -> Build -> включаем "Website (HTML/ASP.NET)" (на самом деле там ещё и php есть, удалить можно в post build event. И ещё одна ремарка: build event'ы могут не работать при сборке из студии и SHFB - собирайте через msbuild).

Как только вы добавите Website, вы сможете обнаружить следующую проблему: оба хелпа оказываются в одном фолдере. Ненаглядно, неудобно, и не комильфо. Идём в свойства проекта -> Plug-Ins -> Output Deployment -> Add. Здесь указываем относительные пути для копирования. 
<spoiler title="Output Deployment plugin"><img src="//habrastorage.org/files/173/31c/f71/17331cf71225437d92ebe98019460a94.png"/></spoiler>


Осталось совсем немного, чтобы привести проект в порядок. 
В каталоге Website/html все файлы вида [GUID].htm. Чтобы это исправить заходим в свойства проекта -> Help File и меняем свойство "Topic file naming method" с "GUID" на более удобочитаемое "Member name". Теперь адрес в строке браузера будет отражать страницу, на которой находится пользователь. 
В тех местах, где отсутствует документация, в хелпе появляются красные предупреждающие надписи "Missing documentation for ...". 
<img src="//habrastorage.org/files/e2e/1d0/f7e/e2e1d0f7e5504dec9b045341d25d840c.png"/>
 Такие надписи удобны при разработке, но совершенно неприемлемы в готовой документации. Чтобы их убрать идём в свойства проекта -> Missing Tags и выбираем, какие элементы не должны выдавать сообщения, если у них отсутствует документация. Так же в данный момент используются языки C#, VB, C++, F#. Свойства проекта -> Help File -> Syntax Filters и выбираем только те языки, которые необходимо.

<h4>Создадим пару страничек</h4>
Для начала удаляем папку Version History со всем содержимым и Welcome.aml страницу из проекта. Структура документации строится именно в файле ContentLayout.content, так что придётся почистить и этот файл.
В большинстве случаев, при создании новой страницы документации, выбирать придётся тип "Conceptual" (типов много, и говорить о них можно долго). При создании новой страницы нужно добавить её в ContentLayout. Возможности конфигурации статических страниц относительно сгенерированого кода и друг друга очень большие, вы сможете дерево топиков составить так, как захотите.

Страницы документации ссылаются друг на друга при помощи topic ID. Его можно найти вверху страницы в соответствующем атрибуте.
Пример:<source lang="html">
 &lt;link xlink:href=&quot;b2ac2359-2794-4644-b900-297937ffeaae&quot; /&gt;
</source>
Проблемы начинаются, когда необходимо сослаться на сгенерированные страницы. В этом случае Sandcastle расходится с синтаксисом, который употребляется в метатегах <see />  и использует свой:

<source lang="xml">
<codeEntityReference qualifyHint="true">M:SandcastleSample.Samples.ConstructorsSamples.#ctor(System.String,System.Int32)</codeEntityReference>
<codeEntityReference qualifyHint="true">M:SandcastleSample.Samples.MethodsSamples.MethodWithRefParameter(System.String,System.String@)</codeEntityReference>
</source>

<b>qualifyHint</b> устанавливается в "true", если нужно показывать сигнатуру метода.

<spoiler title="Список оформления ссылок">
<table>
<tr>
<th>Применим к</th><th>Правило</th><th>Пример</th>
</tr>
<tr>
    <td>Методы и свойства с аргументами</td>
    <td>Необходим список аргументов в скобках</td>
    <td>M:Foo.Bar.Func(System.Boolean)</td>
</tr>
<tr>
    <td>Методы и свойства без аргументов</td>
    <td>Скобки не должны быть использованы</td>
    <td>M:Foo.Bar.Func</td>
</tr>
<tr>
    <td>Конструкторы</td>
    <td>Используется #ctor вместо имени. Если у конструктора есть параметры, то используется то же правило, что и для метода с параметрами</td>
    <td>M:Foo.Bar.#ctor</td>
</tr>
<tr>
    <td>Статические конструкторы</td>
    <td>Используется #сctor вместо имени</td>
    <td>M:Foo.Bar.#cctor</td>
</tr>
<tr>
    <td>Финализаторы</td>
    <td>В качестве имени метода используется Finalize </td>
    <td>M:Foo.Bar.Finalize</td>
</tr>
<tr>
    <td>Аргументы</td>
    <td>Разделяются запятыми, без пробелов. Используется их имя с неймспейсом. Т.е. вместо <b>int</b> используется <b>System.Int32</b> и т.д.</td>
    <td>M:Foo.Bar.Func(System.Int32,System.String,Foo.Widget)</td>
</tr>
<tr>
    <td><b>out</b> и <b>ref</b> параметры</td>
    <td>Их имя типа завершается знаком @</td>
    <td>M:Foo.Bar.Func(System.Int32@)</td>
</tr>
<tr>
    <td>Параметры помеченные как <b>params</b></td>
    <td>Нет специальной нотации</td>
    <td></td>
</tr>
<tr>
    <td>Параметры, которые определяют обобщенный тип</td>
    <td>Добавляется символ апострофа с номером обобщенного типа</td>
    <td>T:Foo.Bar`1</td>
</tr>
<tr>
    <td>Массивы в качестве параметров</td>
    <td>Размерность массива можно опускать</td>
    <td>M:Foo.Bar.Func(System.Int32[0:,0:])</td>
</tr>
<tr>
    <td>Параметры, ссылающиеся на такие типы, как List<></td>
    <td>Используется печерисление через запятую аргументов обобщенного типа, заключенные в фигурные скобки</td>
    <td>M:Foo.Bar.Func(System.Collections.Generic.List{System.String})</td>
</tr>
</table>
<a href="http://www.codeproject.com/Articles/366043/Authoring-Documentation-with-DocProject-and-Sandca">Оригинал</a>
</spoiler>
Список большой, и такие вещи приходится просто знать, тут уж ничего не поделаешь.
Хотя можно включить предупреждения "Missing documentation ..." и там можно увидеть, в каком виде Sandcastle ожидает название метода.

<h4>Tips and Tricks</h4>
<ul>
	<li>Существуют разные шаблоны интерфейса: vs2013, vs2010, vs2005, Hana, Prototype. СтОит попробовать как минимум vs2013 и vs2010 - они обе не deprecated, и их поведение отличается. К примеру, в vs2013 после поиска топик открывается в новой вкладке, что у нас на проекте было критично. Также стоит заметить, что на Webhelp можно ссылаться как на Index.aspx, так и на  index.html. Часть функционала во втором случае не будет доступна (например, поиск).</li>
	<li>Чтобы добавить описание к Namespace, включите в него вот такой класс: 
         <source lang="cs">
///<summary>Namespace summary</summary>
///<include file='_Namespace.xml' path='Documentation/*' />    
internal class NamespaceDoc
{
    //EMPTY
}

</source>
То же самое можно сделать и через Sandcastle.
        </li>
	<li> Чтобы

        </li>

</ul>
