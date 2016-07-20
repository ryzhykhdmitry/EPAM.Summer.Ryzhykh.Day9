#### Задание EPAM.Summer.Day9

Реализация задания 4 [здесь](https://github.com/ryzhykhdmitry/EPAM.Summer.Ryzhykh.Day7).

##### Задание 1. Разработать класс для имитации часов с обратным отсчетом, реализующий возможность по истечении назначенного времени (время ожидания предоставляется классу пользователем) передавать сообщение и дополнительную информацию о событии любому подписавшемуся на событие типу. Предусмотреть возможность подписки на событие в нескольких классах. В качестве тестового проекта использовать консольное приложение с интерфейсом командной строки.
##### Задание 2. Реализовать обобщенный алгоритм бинарного поиска (ограничения на параметр типа не использовать!). Разработать unit-тесты.
##### Задание 3. Тестовый файл содержит некоторую информацию. Разработать приложение, позволяющее определить частоту встречаемости слов в тексте.
##### Задание 4.- Для выполнения основных операций со списком книг (класс Book, день 7), который можно загрузить и,

если возникнет необходимость, сохранить в некоторое хранилище (пока двоичный файл) разработать класс
BookListService (как сервис для работы с коллекцией книг) с функциональностью
 AddBook (добавить книгу, если такой книги нет, в противном случае выбросить исключение);
 RemoveBook (удалить книгу, если она есть, в противном случае выбросить исключение);
 FindBookByTag (найти книгу по заданному критерию);
 SortBooksByTag (отсортировать список книг по заданному критерию).
Для работы с файлами использовать только классы BinaryReader, BinaryWriter.
- Реализовать возможность логирования сообщений различного уровня.
(https://github.com/NLog/NLog/wiki).
- Работу классов продемонстрировать на примере консольного приложения.