Setting up a database for MS SQL

1. Open the project in Visual Studio
2. In appsetting.json (path WebApiProject\appsetting.json) specify server name
3. Go into the Project Manager Console and install the dotnet-ef library (dotnet tool install --global --version=3.1 dotnet-ef)
4. In the console navigate to the WebApiProject directory cd .\WebApiProject
5. Initialize the migration in the current directory (dotnet ef migrations add CreateInitial)
6. Update the database (dotnet ef database update)
7. Log in to the server via SSMS and check the created database
8. Run the project through debugging

Настройка БД для MS SQL

1. Открываем проект в Visual Studio
2. В appsetting.json (путь WebApiProject\appsetting.json) указываем имя сервера
3. Заходим в Консоль диспетчера проектов и устанавливаем библиотеку (dotnet tool install --global --version=3.1 dotnet-ef)
4. В консоли переходим в директорию WebApiProject cd .\WebApiProject
5. Инициализируем миграцию в текущем директории (dotnet ef migrations add CreateInitial)
6. Обновим базу данных (dotnet ef database update)
7. Заходим на сервер через SSMS и проверяем созданную БД
8. Запускаем проект через отладку
