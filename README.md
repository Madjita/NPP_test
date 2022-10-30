# NPP_test
Для запуска (Terminal or cmd):

Если .Net Framework:
	1) Скачиваем проект.
	2) Открываем Microsoft SQL Server Manegment Studio, подключаемся к своему серверу и через правую кнопку мыши нажимаем "Restore databse...";
	3) Выбираем загрузить из файла "test_npp.bak" - лежит в корне проекта.
	4) Заходим в папку "test_npp_api_netFramework\test_npp_api_netFramework" и открываем файл "Web.config", где находим строку подключения к базе "DbConnectionLocalhost" и меняем "connectionString= <свою>" на свою естественно :D
	5) Папка: test_npp - является Project .Net core 6  запускается стандартно =)
	6) Папка: front_npp_test - является React Project запускается командой (естественно не на продакшин, а для отладки):
	    npm start
	7) Переходим на api: https://localhost:44318/Help
	8) Переходим на сайт: http://localhost:3000/
	9) Балуемся
	
Если .Net Core:

1) переходим в каталог test_npp к примеру так:
  cd <путь к паке>/test_npp

2) запускаем создание БД (предварительно установите MS SQL Server):
    dotnet ef databse update

3) Папка: test_npp - является Project .Net core 6  запускается стандартно =)
4) Папка: front_npp_test - является React Project запускается командой (естественно не на продакшин, а для отладки):

    npm start

5) Переходим на api: http://localhost:5148/swagger/index.html
6) Переходим на сайт: http://localhost:3000/
7) Балуемся

P.s: 
    Если есть проблемы подключения к базе на пункте 2 или с dotnet build, то
    откройте файл appsettings.json
    и замените строку 
    
    "DefaultConnection": "server=localhost,1433;database=test_npp;User Id=SA;password=Password123@jkl;Trusted_Connection=False;MultipleActiveResultSets=True"

    На свою к примеру:
        "DefaultConnection": "server=<Имя вашей базы или компьютера>\\SQLEXPRESS;database=nts;Trusted_Connection=True;"

Тестовое НПП <Радиосвязь> отдел 5005

Создать Web application используя ANTD:

БД:
1) Таблица инструментов, с колонками id, наименование инструмента, количество инструментов
2) Таблица пользователей, с id и ФИО
3) Сводная таблица, id иснтрумента,id пользователя, количество выданного инструмента

Front:
На клиентской части приложения необходимо выподить форму с таблицей, которая содержит следующие поля:
1) Наименование инструмента
2) ФИО получателя
3) Количество выданного
4) Кнопка "удалить"

Требуется функционал:
1) Выводить в таблицу информаци из БД.
2) При нажатии на кнопку "добавить запсь" в таблице должа появиться строка с элементами "Select" а так же кнопки "сохранить" и "отменить". В столбце "Наименование инструмента" необходимо вывести инструмент, количество которого больше, чем кол-во пользователей, владеющих им. В столбце ФИО вывети пользователей из БД.
3) При нажатии на кнопку "Сохранить", данные сохраняются в БД и отображаются в таблице, без перезагрузки страницы. 
4) При нажатии кнопки "отмена", строка удаляется, данные в БД и таблица не меняется.
5) При нажатии на кнопку "Удалить", необходимо указывать количество удаляемого инструмента, данные удаляются из БД, таблица изменяется без перезагрузки страницы.


![Alt text](tesst_npp_api.png?raw=true "API")

![Alt text](add_1.png?raw=true "Add 1")

![Alt text](add_2.png?raw=true "Add 2")
![Alt text](add_3.png?raw=true "Add 3")
![Alt text](add_cansel.png?raw=true "add_cansel")
![Alt text](delete_count.png?raw=true "delete_count")
![Alt text](delete_approve.png?raw=true "delete_approve")
![Alt text](delete_res.png?raw=true "delete_res")
