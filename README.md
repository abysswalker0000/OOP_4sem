# Сервис для рецензий на игры в формате веб-приложения

## Казакевич Георгий, группа 253504

Проект представляет собой веб-сайт для публикации и просмотра обзоров на видеоигры.


**Функционал:**
* Регистрация пользователя
* Редактирование профиля пользователя
* Создание и просмотр обзоров
* Добавление обзоров, используя Markdown для форматирования текста
* Лента обзоров
* Комментирование обзоров

**Диаграмма классов**

![oopfinal](https://github.com/abysswalker0000/OOP_4sem/assets/122158359/ef1b25c4-8b81-4f8c-b9ba-9f5e42a1a2f5)


**Описание моделей памяти**
* User (Пользователь): Эта модель данных содержит информацию о пользователях сайта. Пользователи могут регистрироваться, входить в систему, публиковать обзоры и комментировать чужие обзоры.
* UserProfile (Профиль пользователя): Профиль пользователя включает в себя дополнительные сведения о пользователе, такие как биография и аватар.
* Review (Обзор): Обзор содержит информацию о конкретной игре, включая название игры, оценку, текст обзора в формате Markdown и HTML, а также дату публикации.
* Game (Игра): В этой модели данных хранится информация об играх, включая название, описание, жанр, дату выхода и список достижений.
* Achievement (Достижение): Модель описывает достижения, связанные с игрой, и содержит информацию о названии достижения, описании и уровне сложности.
* Comment (Комментарий): Комментарии пользователей к обзорам, содержащие текст комментария и дату публикации.
* MarkdownParser (Парсер Markdown): Утилитарный класс, отвечающий за преобразование текста в формате Markdown в HTML. Эта модель не хранит данных и используется только для обработки текста обзоров.
* Feed (Лента обзоров): Список обзоров, отображаемый на главной странице сайта. Лента обновляется в реальном времени и показывает последние обзоры, опубликованные пользователями.




