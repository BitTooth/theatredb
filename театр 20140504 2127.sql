-- Скрипт сгенерирован Devart dbForge Studio for MySQL, Версия 5.0.97.1
-- Домашняя страница продукта: http://www.devart.com/ru/dbforge/mysql/studio
-- Дата скрипта: 04.05.2014 21:27:24
-- Версия сервера: 5.5.30
-- Версия клиента: 4.1

-- 
-- Отключение внешних ключей
-- 
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;

-- 
-- Установка кодировки, с использованием которой клиент будет посылать запросы на сервер
--
SET NAMES 'utf8';

-- 
-- Установка базы данных по умолчанию
--
USE `театр`;

--
-- Описание для таблицы `должность`
--
DROP TABLE IF EXISTS `должность`;
CREATE TABLE `должность` (
  `ID_Должности` INT(11) NOT NULL AUTO_INCREMENT,
  `Название` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`ID_Должности`)
)
ENGINE = INNODB
AUTO_INCREMENT = 11
AVG_ROW_LENGTH = 1638
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

--
-- Описание для таблицы `жанры`
--
DROP TABLE IF EXISTS `жанры`;
CREATE TABLE `жанры` (
  `id_жанра` INT(11) NOT NULL AUTO_INCREMENT,
  `Название_жанра` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`id_жанра`)
)
ENGINE = INNODB
AUTO_INCREMENT = 11
AVG_ROW_LENGTH = 1638
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

--
-- Описание для таблицы `зал`
--
DROP TABLE IF EXISTS `зал`;
CREATE TABLE `зал` (
  `Название` VARCHAR(255) NOT NULL,
  ID INT(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (ID)
)
ENGINE = INNODB
AUTO_INCREMENT = 10
AVG_ROW_LENGTH = 1820
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

--
-- Описание для таблицы `посетители`
--
DROP TABLE IF EXISTS `посетители`;
CREATE TABLE `посетители` (
  id_login INT(11) NOT NULL AUTO_INCREMENT,
  `пароль` VARCHAR(255) NOT NULL,
  email VARCHAR(255) NOT NULL,
  PRIMARY KEY (id_login)
)
ENGINE = INNODB
AUTO_INCREMENT = 5
AVG_ROW_LENGTH = 4096
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

--
-- Описание для таблицы `реквизит`
--
DROP TABLE IF EXISTS `реквизит`;
CREATE TABLE `реквизит` (
  `тип` VARCHAR(255) NOT NULL,
  `инвент_ном` INT(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`инвент_ном`)
)
ENGINE = INNODB
AUTO_INCREMENT = 8
AVG_ROW_LENGTH = 2340
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

--
-- Описание для таблицы `скидка`
--
DROP TABLE IF EXISTS `скидка`;
CREATE TABLE `скидка` (
  `Название_скидки` VARCHAR(255) NOT NULL,
  `%_скидки` INT(11) NOT NULL,
  `id_скидки` INT(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id_скидки`)
)
ENGINE = INNODB
AUTO_INCREMENT = 6
AVG_ROW_LENGTH = 3276
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

--
-- Описание для таблицы `места_в_зале`
--
DROP TABLE IF EXISTS `места_в_зале`;
CREATE TABLE `места_в_зале` (
  `ряд` INT(11) NOT NULL,
  `номер_места` INT(11) NOT NULL,
  `Наценка` VARCHAR(255) NOT NULL,
  `зал` INT(11) NOT NULL,
  `ID_Места` INT(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`ID_Места`),
  UNIQUE INDEX `UK_места_в_зале` (`ряд`, `номер_места`),
  CONSTRAINT `FK_места_в_зале_зал_ID` FOREIGN KEY (`зал`)
    REFERENCES `зал`(ID) ON DELETE NO ACTION ON UPDATE CASCADE
)
ENGINE = INNODB
AUTO_INCREMENT = 10
AVG_ROW_LENGTH = 1820
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

--
-- Описание для таблицы `сотрудники`
--
DROP TABLE IF EXISTS `сотрудники`;
CREATE TABLE `сотрудники` (
  `ФИО` VARCHAR(255) NOT NULL,
  `ID_Должности` INT(11) NOT NULL,
  `Адрес` VARCHAR(255) NOT NULL,
  `телефон` VARCHAR(255) DEFAULT NULL,
  `паспорт` INT(11) NOT NULL,
  `id_сотрудника` INT(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id_сотрудника`),
  UNIQUE INDEX `паспорт` (`паспорт`),
  CONSTRAINT `FK_сотрудники_должность_ID_Должности` FOREIGN KEY (`ID_Должности`)
    REFERENCES `должность`(`ID_Должности`) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE = INNODB
AUTO_INCREMENT = 16
AVG_ROW_LENGTH = 1170
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

--
-- Описание для таблицы `спектакль`
--
DROP TABLE IF EXISTS `спектакль`;
CREATE TABLE `спектакль` (
  `Название` VARCHAR(255) NOT NULL,
  `сюжет` VARCHAR(255) NOT NULL,
  `год_пост` YEAR(4) NOT NULL,
  `кол-во_акт` INT(11) NOT NULL,
  `скидка` INT(11) NOT NULL,
  `ID_Спектакля` INT(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`ID_Спектакля`),
  CONSTRAINT `FK_спектакль_скидка_id_скидки` FOREIGN KEY (`скидка`)
    REFERENCES `скидка`(`id_скидки`) ON DELETE RESTRICT ON UPDATE CASCADE
)
ENGINE = INNODB
AUTO_INCREMENT = 11
AVG_ROW_LENGTH = 1638
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

--
-- Описание для таблицы `жанр_в_спектакле`
--
DROP TABLE IF EXISTS `жанр_в_спектакле`;
CREATE TABLE `жанр_в_спектакле` (
  `id_спектакля` INT(11) NOT NULL,
  `id_жанра` INT(11) NOT NULL,
  ID INT(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (ID),
  CONSTRAINT `FK_жанр_в_спектакле_жанры_id_жанра` FOREIGN KEY (`id_жанра`)
    REFERENCES `жанры`(`id_жанра`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_жанр_в_спектакле_спектакль_ID_Спектакля` FOREIGN KEY (`id_спектакля`)
    REFERENCES `спектакль`(`ID_Спектакля`) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE = INNODB
AUTO_INCREMENT = 11
AVG_ROW_LENGTH = 1638
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

--
-- Описание для таблицы `отзывы`
--
DROP TABLE IF EXISTS `отзывы`;
CREATE TABLE `отзывы` (
  `ID_отзыва` INT(11) NOT NULL AUTO_INCREMENT,
  `отзыв` VARCHAR(1000) DEFAULT NULL,
  `ID_Спектакля` INT(11) NOT NULL,
  id_login INT(11) DEFAULT NULL,
  PRIMARY KEY (`ID_отзыва`),
  CONSTRAINT `FK_отзывы_посетители_id_login` FOREIGN KEY (id_login)
    REFERENCES `посетители`(id_login) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_отзывы_спектакль_ID_Спектакля` FOREIGN KEY (`ID_Спектакля`)
    REFERENCES `спектакль`(`ID_Спектакля`) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE = INNODB
AUTO_INCREMENT = 4
AVG_ROW_LENGTH = 5461
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

--
-- Описание для таблицы `проведение_спектакля`
--
DROP TABLE IF EXISTS `проведение_спектакля`;
CREATE TABLE `проведение_спектакля` (
  `дата_время` DATETIME NOT NULL,
  `id_спектакля` INT(11) NOT NULL,
  `отменён` TINYINT(1) DEFAULT NULL,
  ID INT(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (ID),
  CONSTRAINT `FK_проведение_спектакля_спектакль_ID_Спектакля` FOREIGN KEY (`id_спектакля`)
    REFERENCES `спектакль`(`ID_Спектакля`) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE = INNODB
AUTO_INCREMENT = 11
AVG_ROW_LENGTH = 1638
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

--
-- Описание для таблицы `рек_зад_в_спек`
--
DROP TABLE IF EXISTS `рек_зад_в_спек`;
CREATE TABLE `рек_зад_в_спек` (
  `инвент_ном` INT(11) NOT NULL,
  `id_спектакля` INT(11) NOT NULL,
  ID INT(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (ID),
  CONSTRAINT `FK_рек_зад_в_спек_реквизит_инвент_ном` FOREIGN KEY (`инвент_ном`)
    REFERENCES `реквизит`(`инвент_ном`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_рек_зад_в_спек_спектакль_ID_Спектакля` FOREIGN KEY (`id_спектакля`)
    REFERENCES `спектакль`(`ID_Спектакля`) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE = INNODB
AUTO_INCREMENT = 10
AVG_ROW_LENGTH = 1820
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

--
-- Описание для таблицы `репетиции`
--
DROP TABLE IF EXISTS `репетиции`;
CREATE TABLE `репетиции` (
  `дата_время` DATETIME NOT NULL,
  `id_репетиции` INT(11) NOT NULL AUTO_INCREMENT,
  `id_спектакля` INT(11) NOT NULL,
  PRIMARY KEY (`id_репетиции`),
  CONSTRAINT `FK_репетиции_спектакль_ID_Спектакля` FOREIGN KEY (`id_спектакля`)
    REFERENCES `спектакль`(`ID_Спектакля`) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE = INNODB
AUTO_INCREMENT = 11
AVG_ROW_LENGTH = 1638
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

--
-- Описание для таблицы `билет`
--
DROP TABLE IF EXISTS `билет`;
CREATE TABLE `билет` (
  id INT(11) NOT NULL,
  `цена_билета` VARCHAR(255) NOT NULL,
  `название_скидки` VARCHAR(255) DEFAULT NULL,
  `сдан` TINYINT(1) DEFAULT NULL,
  `ID_Места` INT(11) NOT NULL,
  login INT(11) DEFAULT NULL,
  `id_провед_спект` INT(11) NOT NULL,
  `всего_билетов` INT(11) NOT NULL,
  PRIMARY KEY (id),
  CONSTRAINT `FK_билет_места_в_зале_ID_Места` FOREIGN KEY (`ID_Места`)
    REFERENCES `места_в_зале`(`ID_Места`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_билет_посетители_id_login` FOREIGN KEY (login)
    REFERENCES `посетители`(id_login) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `FK_билет_проведение_спектакля_ID` FOREIGN KEY (`id_провед_спект`)
    REFERENCES `проведение_спектакля`(ID) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE = INNODB
AVG_ROW_LENGTH = 4096
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

--
-- Описание для таблицы `роль_в_пров_спект`
--
DROP TABLE IF EXISTS `роль_в_пров_спект`;
CREATE TABLE `роль_в_пров_спект` (
  `Название` VARCHAR(255) NOT NULL,
  `id_сотрудника` INT(11) NOT NULL,
  ID INT(11) NOT NULL AUTO_INCREMENT,
  `id_пров_спект` INT(11) NOT NULL,
  PRIMARY KEY (ID),
  CONSTRAINT `FK_роль_в_пров_спект_проведение_спектакля_ID` FOREIGN KEY (`id_пров_спект`)
    REFERENCES `проведение_спектакля`(ID) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_роль_в_пров_спект_сотрудники_id_сотрудника` FOREIGN KEY (`id_сотрудника`)
    REFERENCES `сотрудники`(`id_сотрудника`) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE = INNODB
AUTO_INCREMENT = 11
AVG_ROW_LENGTH = 2048
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

--
-- Описание для таблицы `роль_в_реп`
--
DROP TABLE IF EXISTS `роль_в_реп`;
CREATE TABLE `роль_в_реп` (
  ID INT(11) NOT NULL AUTO_INCREMENT,
  `id_репетиции` INT(11) NOT NULL,
  `id_сотрудника` INT(11) NOT NULL,
  PRIMARY KEY (ID),
  CONSTRAINT `FK_роль_в_реп_репетиции_id_репетиции` FOREIGN KEY (`id_репетиции`)
    REFERENCES `репетиции`(`id_репетиции`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_роль_в_реп_сотрудники_id_сотрудника` FOREIGN KEY (`id_сотрудника`)
    REFERENCES `сотрудники`(`id_сотрудника`) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE = INNODB
AUTO_INCREMENT = 10
AVG_ROW_LENGTH = 1820
CHARACTER SET cp1251
COLLATE cp1251_general_ci;

-- 
-- Вывод данных для таблицы `должность`
--
INSERT INTO `должность` VALUES 
  (1, 'Директор театра'),
  (2, 'Управляющий творческими коллективами'),
  (3, 'Кассир'),
  (4, 'Звукооператор'),
  (5, 'Светооператор'),
  (6, 'Актёры'),
  (7, 'Костюмер'),
  (8, 'Уборщики'),
  (9, 'Постановщики'),
  (10, 'Гримёры');

-- 
-- Вывод данных для таблицы `жанры`
--
INSERT INTO `жанры` VALUES 
  (1, 'опера'),
  (2, 'комедия'),
  (3, 'трагикомедия'),
  (4, 'водевиль'),
  (5, 'драма'),
  (6, 'мелодрама '),
  (7, 'мистерия'),
  (8, 'мюзикл'),
  (9, 'моралите'),
  (10, 'пародия');

-- 
-- Вывод данных для таблицы `зал`
--
INSERT INTO `зал` VALUES 
  ('Балкон 1 яруса', 1),
  ('Балкон 2 яруса', 2),
  ('Балкон 3 яруса', 3),
  ('Балкон 4 яруса', 4),
  ('1 ярус', 5),
  ('Бель-этаж', 6),
  ('Амфитеатр', 7),
  ('Партер', 8),
  ('Бенуар', 9);

-- 
-- Вывод данных для таблицы `посетители`
--
INSERT INTO `посетители` VALUES 
  (1, '123', 'q@yandex.ru'),
  (2, '456', 'w@mail.ru'),
  (3, '789', 'e@mail.ru'),
  (4, '100', 'r@yandex.ru');

-- 
-- Вывод данных для таблицы `реквизит`
--
INSERT INTO `реквизит` VALUES 
  ('Стулья', 1),
  ('Цветы', 2),
  ('Оконные рамы', 3),
  ('Костюмы', 4),
  ('Столы', 5),
  ('Бутафория', 6),
  ('Лампы', 7);

-- 
-- Вывод данных для таблицы `скидка`
--
INSERT INTO `скидка` VALUES 
  ('праздничные дни', 10, 1),
  ('буднии дни', 5, 2),
  ('последнии дни месяца', 7, 3),
  ('фестивали', 15, 4),
  ('без скидки', 0, 5);

-- 
-- Вывод данных для таблицы `места_в_зале`
--
INSERT INTO `места_в_зале` VALUES 
  (1, 1, '0', 8, 1),
  (2, 2, '0', 2, 2),
  (3, 3, '5%', 6, 3),
  (5, 10, '0', 1, 4),
  (6, 12, '0', 3, 5),
  (7, 2, '10%', 5, 6),
  (4, 4, '0', 4, 7),
  (10, 4, '0', 7, 8),
  (8, 5, '0', 9, 9);

-- 
-- Вывод данных для таблицы `сотрудники`
--
INSERT INTO `сотрудники` VALUES 
  ('Туган Сохиев Бекмамбетович', 7, 'Московский пр. 54', '556-89-41', 4010421, 1),
  ('Юрий Попко Витальевич', 1, 'Северская 45', '457-10-52', 4010789, 2),
  ('Сухих Константин валеоьевич', 6, 'Большивиков 20', '776-46-12', 4010469, 3),
  ('Богданова Юлия Витальевна', 6, 'Константиновский 2', '147-85-14', 4010745, 4),
  ('Афонин Александр Андреевич', 2, 'Просвещения 53', '559-87-65', 4010123, 5),
  ('Селезнёва Ольга Александровна', 3, 'Бодаевский проезд 5', '552-14-78', 4010742, 6),
  ('Михайлова Анастасия Юрьевна', 10, 'Московский 20', '479-58-60', 4010256, 7),
  ('Суворов Алексей Петрович', 4, 'Олеко Дундича', '123-78-91', 4010854, 8),
  ('Чесноков Андрей Валерьевич', 5, 'Будапештская 1', '456-02-42', 4010236, 9),
  ('Растеряев Игорь Юрьевич', 8, 'Ленинский пр. 35', '110-53-78', 4010785, 10),
  ('Дмитрева Елизавета Петровна', 9, 'Сухова 45', '456-85-42', 4010741, 11),
  ('Червинский Павел Олегович', 6, 'Невский 105', '425-87-45', 4010753, 12),
  ('Промохова Валентина Николаевна', 6, 'Пролетарская 12', '412-78-02', 4010321, 13),
  ('Семёнов Дмитрий Иванович', 6, 'Пирогова 72', '128-96-45', 4010258, 14);

-- 
-- Вывод данных для таблицы `спектакль`
--
INSERT INTO `спектакль` VALUES 
  ('Юнона и Авось', 'История любви русского путешественника, камергера, графа Николая Петровича Резанова и юной красавицы Кончиты, дочери  испанского губернатора Сан-Фран­циско, словно создана для музыкального спектакля.', 1999, 2, 5, 1),
  ('Ромео и Джульетта', 'Трагическая история любви двух сердец.', 2000, 2, 2, 2),
  ('С наступающим', 'Новогодняя история двух друзей.', 2010, 1, 5, 3),
  ('Обычное дело', 'Герои попадают в самые нелепые ситуации. И выпутываются из них самыми небанальными способами. ', 2012, 1, 1, 4),
  ('Чховъ', 'Сценические истории по «коротким» пьесам Антона Павловича Чехова - «Предложение», «Юбилей» и «О вреде табака».', 2009, 2, 3, 5),
  ('Ложь во спасение', 'В основе нового спектакля лежит очень популярная в нашей стране пьеса испанского драматурга Алехандро Касоны «Деревья умирают стоя».', 2012, 1, 4, 6),
  ('Литургия оглашенных', 'Библейские сюжеты.', 1992, 2, 5, 7),
  ('Призрак Оперы', 'Сюжет мюзикла заключается в том,чтобы показать зрителю силу истинной любви,показать,что даже самое чёрствое сердце может стать более добрым и мягким.', 1998, 2, 5, 8),
  ('Мудрость', 'Филосовская история, повествующая нравственность людей.', 2000, 3, 3, 9),
  ('Необыкновенный концерт', 'Спектакль представляет собой пародию на различные жанры искусства, обычно входящие в сборный концерт: хоровое пение, опера, оперетта, авангардная музыка, цирковые номера, бальные танцы, цыганские романсы, зарубежная эстрада.', 2003, 1, 2, 10);

-- 
-- Вывод данных для таблицы `жанр_в_спектакле`
--
INSERT INTO `жанр_в_спектакле` VALUES 
  (1, 1, 1),
  (2, 3, 2),
  (3, 2, 3),
  (4, 5, 4),
  (5, 4, 5),
  (6, 6, 6),
  (7, 7, 7),
  (8, 8, 8),
  (9, 9, 9),
  (10, 10, 10);

-- 
-- Вывод данных для таблицы `отзывы`
--
INSERT INTO `отзывы` VALUES 
  (1, 'Смотрела на прошлой неделе новую постановку, была в восторге. Для интереса посмотрела в интернете старую, с Караченцовым.При всем уважении, все таки современная постановка мне понравилась гораздо больше, как-то живее и напряженнее она была, и исполнение песен интересней.Ну и танцы более страстные, конечно, чем 20 лет назад.', 1, 1),
  (2, 'Посмотрели вчера спектакль "Ромео и Джульетта" в Сатириконе с супругом. Впечачатления у нас одинаково неоднозначные: постановка спорная, но оправдать её можно тем, что современную молодёжь заинтересовать классикой, к сожалению, довольно сложно, а учитывая, что в зале было очень много школьников, то их внимание сразу было привлечено к катающимся на bmx подросткам, катающихся по сцене, которая была спроектирована в виде рампы, а костюмы и спецэфекты дополняли картину.', 2, 2),
  (3, 'Спектакль очень понравился. Игра актеров была на высшем уровне.  Местами грустный, смешной и очень жизненный поднимает настроение, окутывая атмосферой праздника. Одним словом полностью соответствует своему названию. Определенно рекомендую посетить одну из знаковых пьес проходящих на московских театральных площадках.', 3, 3);

-- 
-- Вывод данных для таблицы `проведение_спектакля`
--
INSERT INTO `проведение_спектакля` VALUES 
  ('2015-05-28 21:27:20', 1, 0, 1),
  ('2014-05-31 11:54:25', 2, 0, 2),
  ('2014-06-11 11:52:35', 3, 0, 3),
  ('2014-07-01 11:52:56', 4, 0, 4),
  ('2015-07-30 11:53:08', 5, 0, 5),
  ('2015-08-07 11:53:17', 6, 0, 6),
  ('2014-08-28 11:53:48', 7, 0, 7),
  ('2014-10-08 11:55:17', 8, 0, 8),
  ('2014-11-19 11:55:32', 9, 0, 9),
  ('2014-08-14 11:55:49', 10, 0, 10);

-- 
-- Вывод данных для таблицы `рек_зад_в_спек`
--
INSERT INTO `рек_зад_в_спек` VALUES 
  (1, 1, 1),
  (2, 2, 2),
  (3, 3, 3),
  (4, 4, 4),
  (4, 5, 5),
  (5, 6, 6),
  (6, 7, 7),
  (7, 8, 8),
  (4, 9, 9);

-- 
-- Вывод данных для таблицы `репетиции`
--
INSERT INTO `репетиции` VALUES 
  ('2014-05-19 12:36:58', 1, 1),
  ('2014-05-26 12:38:50', 2, 2),
  ('2014-06-03 12:39:02', 3, 3),
  ('2014-06-26 12:39:19', 4, 4),
  ('2014-07-22 12:39:37', 5, 5),
  ('2014-05-03 12:41:16', 6, 6),
  ('2014-08-20 12:41:38', 7, 7),
  ('2014-10-02 12:43:13', 8, 8),
  ('2014-11-06 12:44:01', 9, 9),
  ('2014-08-08 12:44:38', 10, 10);

-- 
-- Вывод данных для таблицы `билет`
--
INSERT INTO `билет` VALUES 
  (1, '1000', '0', 0, 2, 2, 1, 1000),
  (2, '1500', 'буднии дни', 0, 1, 2, 2, 1000),
  (3, '600', '0', 0, 3, 4, 3, 1000),
  (4, '3000', 'праздничные дни', 0, 6, NULL, 4, 1000);

-- 
-- Вывод данных для таблицы `роль_в_пров_спект`
--
INSERT INTO `роль_в_пров_спект` VALUES 
  ('Граф Николай Резанов', 3, 1, 1),
  ('Джульетта Капулетти', 4, 2, 2),
  ('Русский', 12, 3, 3),
  ('Джейн', 13, 4, 4),
  ('Брат', 14, 5, 5),
  ('Дед', 3, 6, 6),
  ('Заключённый Данилов', 14, 7, 7),
  ('Дочурка', 4, 8, 9);

-- 
-- Вывод данных для таблицы `роль_в_реп`
--
INSERT INTO `роль_в_реп` VALUES 
  (1, 1, 3),
  (2, 2, 4),
  (3, 3, 12),
  (4, 4, 13),
  (5, 5, 14),
  (6, 6, 3),
  (7, 7, 14),
  (8, 8, 4),
  (9, 9, 12);

-- 
-- Включение внешних ключей
-- 
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;