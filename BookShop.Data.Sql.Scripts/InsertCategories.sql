--MainCategory
if not exists(select * from MainCategory where NameForDisplay like 'Książki')
insert into MainCategory(NameForDisplay, Name) values('Książki', 'Ksiazki');
if not exists(select * from MainCategory where NameForDisplay like 'Podręczniki')
insert into MainCategory(NameForDisplay, Name) values('Podręczniki', 'Podreczniki');
if not exists(select * from MainCategory where NameForDisplay like 'Ebooki')
insert into MainCategory(NameForDisplay, Name) values('Ebooki', 'Ebooki');
if not exists(select * from MainCategory where NameForDisplay like 'Audiobooki')
insert into MainCategory(NameForDisplay, Name) values('Audiobooki', 'Audiobooki');
if not exists(select * from MainCategory where NameForDisplay like 'Komiksy')
insert into MainCategory(NameForDisplay, Name) values('Komiksy', 'Komiksy');




--SubMainCategory Książki
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Literatura piękna' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Literatura piękna', 'Literatura-piekna', (select Id from MainCategory where NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Literatura faktu' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Literatura faktu', 'Literatura-faktu', (select Id from MainCategory where NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Poradniki' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Poradniki', 'Poradniki', (select Id from MainCategory where NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Książki dla dzieci' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Książki dla dzieci', 'Ksiazki-dla-dzieci', (select Id from MainCategory where NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Książki dla młodzieży' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Książki dla młodzieży', 'Ksiazki-dla-mlodziezy', (select Id from MainCategory where NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Książki dla kobiet' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Książki dla kobiet', 'Ksiazki-dla-kobiet', (select Id from MainCategory where NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Książki naukowe i popularnonaukowe' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Książki naukowe i popularnonaukowe', 'Ksiazki-naukowe-i-popularnonaukowe', (select Id from MainCategory where NameForDisplay like 'Książki'));


--SubMainCategory Podręczniki
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Przedszkole' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Podręczniki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Przedszkole', 'Przedszkole', (select Id from MainCategory where NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Szkoła podstawowa' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Podręczniki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Szkoła podstawowa', 'Szkola-podstawowa', (select Id from MainCategory where NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Gimnazjum' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Podręczniki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Gimnazjum', 'Gimnazjum', (select Id from MainCategory where NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Liceum' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Podręczniki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Liceum', 'Liceum', (select Id from MainCategory where NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Technikum' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Podręczniki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Technikum', 'Technikum', (select Id from MainCategory where NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Szkoła zawodowa' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Podręczniki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Szkoła zawodowa', 'Szkola-zawodowa', (select Id from MainCategory where NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Szkoły wyższe' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Podręczniki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Szkoły wyższe', 'Szkoly-wyzsze', (select Id from MainCategory where NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Lektury szkolne' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Podręczniki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Lektury szkolne', 'Lektury-szkolne', (select Id from MainCategory where NameForDisplay like 'Podręczniki'));


--SubMainCategory Ebooki
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Literatura piękna' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Ebooki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Literatura piękna', 'Literatura-piekna', (select Id from MainCategory where NameForDisplay like 'Ebooki'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Literatura faktu' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Ebooki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Literatura faktu', 'Literatura-faktu', (select Id from MainCategory where NameForDisplay like 'Ebooki'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Poradniki' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Ebooki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Poradniki', 'Poradniki', (select Id from MainCategory where NameForDisplay like 'Ebooki'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Ebooki dla dzieci' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Ebooki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Ebooki dla dzieci', 'Ebooki-dla-dzieci', (select Id from MainCategory where NameForDisplay like 'Ebooki'));


--SubMainCategory Audiobooki
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Dla dzieci' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Audiobooki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Dla dzieci', 'Dla-dzieci', (select Id from MainCategory where NameForDisplay like 'Audiobooki'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Dla kobiet' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Audiobooki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Dla kobiet', 'Dla-kobiet', (select Id from MainCategory where NameForDisplay like 'Audiobooki'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Dla młodzieży' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Audiobooki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Dla młodzieży', 'Dla-mlodziezy', (select Id from MainCategory where NameForDisplay like 'Audiobooki'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Fantastyka' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Audiobooki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Fantastyka', 'Fantastyka', (select Id from MainCategory where NameForDisplay like 'Audiobooki'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Historia, powieści historyczne' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Audiobooki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Historia, powieści historyczne', 'Historia-powiesci-historyczne', (select Id from MainCategory where NameForDisplay like 'Audiobooki'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Kryminał, przygoda, sensacja' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Audiobooki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Kryminał, przygoda, sensacja', 'Kryminal-przygoda-sensacja', (select Id from MainCategory where NameForDisplay like 'Audiobooki'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Lektury szkolne i opracowania' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Audiobooki'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Lektury szkolne i opracowania', 'Lektury-szkolne-i-opracowania', (select Id from MainCategory where NameForDisplay like 'Audiobooki'));


--SubMainCategory Komiksy
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Komiksy dla dzieci' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Komiksy'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Komiksy dla dzieci', 'Komiksy-dla-dzieci', (select Id from MainCategory where NameForDisplay like 'Komiksy'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Manga i anime' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Komiksy'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Manga i anime', 'Manga-i-anime', (select Id from MainCategory where NameForDisplay like 'Komiksy'));
if not exists(select NameForDisplay, MainCategoryId from SubMainCategory where NameForDisplay like 'Pozostałe komiksy' and MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Komiksy'))
insert into SubMainCategory(NameForDisplay, Name, MainCategoryId) values('Pozostałe komiksy', 'Pozostale-komiksy', (select Id from MainCategory where NameForDisplay like 'Komiksy'));


--BookCategory Ksiązki/Literatura piękna
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Powieść społeczno-obyczajowa' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Powieść społeczno-obyczajowa', 'Powiesc-spoleczno-obyczajowa', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and m.NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Sensacja, kryminał, thriller' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Sensacja, kryminał, thriller', 'Sensacja-kryminal-thriller', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and m.NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Fantastyka' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Fantastyka', 'Fantastyka', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and m.NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Powieść polska' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Powieść polska', 'Powiesc-polska', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and m.NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Powieść zagraniczna' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Powieść zagraniczna', 'Powiesc-zagraniczna', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and m.NameForDisplay like 'Książki'));


--BookCategory Ksiązki/Literatura faktu
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Wspomnienia, dzienniki, listy' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Wspomnienia, dzienniki, listy', 'Wspomnienia-dzienniki-listy', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and m.NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Biografie, wywiady' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Biografie, wywiady', 'Biografie-wywiady', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and m.NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Eseje, felietony' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Eseje, felietony', 'Eseje-felietony', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and m.NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Reportaże' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Reportaże', 'Reportaze', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and m.NameForDisplay like 'Książki'));


--BookCategory Ksiązki/Poradniki
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Książki kucharskie' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Książki kucharskie', 'Ksiazki-kucharskie', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Diety, fitness, ćwiczenia' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Diety, fitness, ćwiczenia', 'Diety-fitness-cwiczenia', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Dom i ogród' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Dom i ogród', 'Dom-i-ogrod', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Hobby, sport, rekreacja' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Hobby, sport, rekreacja', 'Hobby-sport-rekreacja', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Rozwój osobisty, kariera' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Rozwój osobisty, kariera', 'Rozwoj-osobisty-kariera', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Związki, rodzina, dzieci' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Związki, rodzina, dzieci', 'Zwiazki-rodzina-dzieci', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Zdrowie i uroda' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Zdrowie i uroda', 'Zdrowie-i-uroda', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Książki'));


--BookCategory Ksiązki/Książki dla dzieci
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Bajki, baśnie, legendy' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla dzieci' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Bajki, baśnie, legendy', 'Bajki-basnie-legendy', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla dzieci' and m.NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Kolorowanki, wycinanki' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla dzieci' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Kolorowanki, wycinanki', 'Kolorowanki-wycinanki', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla dzieci' and m.NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Książki dla dzieci do 6 lat' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla dzieci' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Książki dla dzieci do 6 lat', 'Ksiazki-dla-dzieci-do-6-lat', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla dzieci' and m.NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Książki dla dzieci od 7 lat' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla dzieci' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Książki dla dzieci od 7 lat', 'Ksiazki-dla-dzieci-do-7-lat', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla dzieci' and m.NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Wiersze, rymowanki' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla dzieci' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Wiersze, rymowanki', 'Wiersze-rymowanki', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla dzieci' and m.NameForDisplay like 'Książki'));


--BookCategory Ksiązki/Książki dla młodzieży
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Literatura młodzieżowa zagraniczna' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla młodzieży' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Literatura młodzieżowa zagraniczna', 'Literatura-mlodziezowa-zagraniczna', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla młodzieży' and m.NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Powieści dla dziewczyn - polskie' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla młodzieży' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Powieści dla dziewczyn - polskie', 'Powiesci-dla-dziewczyn-polskie', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla młodzieży' and m.NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Powieści dla dziewczyn - zagraniczne' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla młodzieży' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Powieści dla dziewczyn - zagraniczne', 'Powiesci-dla-dziewczyn-zagraniczne', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla młodzieży' and m.NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Pozostała literatura młodzieżowa' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla młodzieży' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Pozostała literatura młodzieżowa', 'Pozostala-literatura-mlodziezowa', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla młodzieży' and m.NameForDisplay like 'Książki'));


--BookCategory Ksiązki/Książki dla kobiet
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Literatura obyczajowa' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla kobiet' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Literatura obyczajowa', 'Literatura-obyczajowa', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla kobiet' and m.NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Powieści erotyczne' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla kobiet' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Powieści erotyczne', 'Powiesci-erotyczne', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla kobiet' and m.NameForDisplay like 'Książki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Romans' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla kobiet' and m.NameForDisplay like 'Książki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Romans', 'Romans', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Książki dla kobiet' and m.NameForDisplay like 'Książki'));




--BookCategory Podręczniki/Przedszkole
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like '3-latek' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Przedszkole' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('3-latek', '3-latek', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Przedszkole' and m.NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like '4-latek' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Przedszkole' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('4-latek', '4-latek', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Przedszkole' and m.NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like '5-latek' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Przedszkole' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('5-latek', '5-latek', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Przedszkole' and m.NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like '6-latek' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Przedszkole' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('6-latek', '6-latek', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Przedszkole' and m.NameForDisplay like 'Podręczniki'));


--BookCategory Podręczniki/Szkoła podstawowa
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Klasa 1' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Szkoła podstawowa' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Klasa 1', 'Klasa-1', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Szkoła podstawowa' and m.NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Klasa 2' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Szkoła podstawowa' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Klasa 2', 'Klasa-2', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Szkoła podstawowa' and m.NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Klasa 3' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Szkoła podstawowa' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Klasa 3', 'Klasa-3', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Szkoła podstawowa' and m.NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Klasa 4' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Szkoła podstawowa' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Klasa 4', 'Klasa-4', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Szkoła podstawowa' and m.NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Klasa 5' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Szkoła podstawowa' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Klasa 5', 'Klasa-5', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Szkoła podstawowa' and m.NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Klasa 6' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Szkoła podstawowa' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Klasa 6', 'Klasa 6', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Szkoła podstawowa' and m.NameForDisplay like 'Podręczniki'));


--BookCategory Podręczniki/Gimnazjum
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Klasa 1' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Gimnazjum' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Klasa 1', 'Klasa-1', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Gimnazjum' and m.NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Klasa 2' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Gimnazjum' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Klasa 2', 'Klasa-2', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Gimnazjum' and m.NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Klasa 3' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Gimnazjum' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Klasa 3', 'Klasa-3', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Gimnazjum' and m.NameForDisplay like 'Podręczniki'));


--BookCategory Podręczniki/Liceum
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Klasa 1' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Liceum' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Klasa 1', 'Klasa-1', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Liceum' and m.NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Klasa 2' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Liceum' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Klasa 2', 'Klasa-2', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Liceum' and m.NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Klasa 3' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Liceum' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Klasa 3', 'Klasa-3', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Liceum' and m.NameForDisplay like 'Podręczniki'));


--BookCategory Podręczniki/Technikum
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Klasa 1' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Technikum' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Klasa 1', 'Klasa-1', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Technikum' and m.NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Klasa 2' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Technikum' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Klasa 2', 'Klasa-2', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Technikum' and m.NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Klasa 3' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Technikum' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Klasa 3', 'Klasa-3', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Technikum' and m.NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Klasa 4' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Technikum' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Klasa 4', 'Klasa-4', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Technikum' and m.NameForDisplay like 'Podręczniki'));


--BookCategory Podręczniki/Szkoła zawodowa
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Klasa 1' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Szkoła zawodowa' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Klasa 1', 'Klasa-1', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Szkoła zawodowa' and m.NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Klasa 2' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Szkoła zawodowa' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Klasa 2', 'Klasa-2', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Szkoła zawodowa' and m.NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Klasa 3' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Szkoła zawodowa' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Klasa 3', 'Klasa-3', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Szkoła zawodowa' and m.NameForDisplay like 'Podręczniki'));


--BookCategory Podręczniki/Lektury szkolne
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Lektury do podstawówki' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Lektury szkolne' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Lektury do podstawówki', 'Lektury-do-podstawowki', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Lektury szkolne' and m.NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Lektury do gimnazjum' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Lektury szkolne' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Lektury do gimnazjum', 'Lektury-do-gimnazjum', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Lektury szkolne' and m.NameForDisplay like 'Podręczniki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Lektury do liceum i technikum' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Lektury szkolne' and m.NameForDisplay like 'Podręczniki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Lektury do liceum i technikum', 'Lektury-do-liceum-i-technikum', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Lektury szkolne' and m.NameForDisplay like 'Podręczniki'));




--BookCategory Ebooki/Literatura piękna
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Powieść' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and m.NameForDisplay like 'Ebooki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Powieść', 'Powiesc', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and m.NameForDisplay like 'Ebooki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Romans' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and m.NameForDisplay like 'Ebooki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Romans', 'Romans', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and m.NameForDisplay like 'Ebooki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Sensacja, kryminał, thriller' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and m.NameForDisplay like 'Ebooki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Sensacja, kryminał, thriller', 'Sensacja-kryminal-thriller', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and m.NameForDisplay like 'Ebooki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Fantastyka' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and m.NameForDisplay like 'Ebooki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Fantastyka', 'Fantastyka', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and m.NameForDisplay like 'Ebooki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Literatura obcojęzyczna' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and m.NameForDisplay like 'Ebooki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Literatura obcojęzyczna', 'Literatura-obcojezyczna', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and m.NameForDisplay like 'Ebooki'));


--BookCategory Ebooki/Literatura faktu
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Biografie, wspomnienia, wywiady' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and m.NameForDisplay like 'Ebooki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Biografie, wspomnienia, wywiady', 'Biografie-wspomnienia-wywiady', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and m.NameForDisplay like 'Ebooki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Listy' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and m.NameForDisplay like 'Ebooki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Listy', 'Listy', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and m.NameForDisplay like 'Ebooki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Reportaż' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and m.NameForDisplay like 'Ebooki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Reportaż', 'Reportaz', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and m.NameForDisplay like 'Ebooki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Publicystyka' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and m.NameForDisplay like 'Ebooki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Publicystyka', 'Publicystyka', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and m.NameForDisplay like 'Ebooki'));


--BookCategory Ebooki/Poradniki
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Kulinaria' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Ebooki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Kulinaria', 'Kulinaria', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Ebooki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Dom, ogród' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Ebooki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Dom, ogród', 'Dom-ogrod', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Ebooki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Hobby, czas wolny' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Ebooki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Hobby, czas wolny', 'Hobby-czas-wolny', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Ebooki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Sport' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Ebooki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Sport', 'Sport', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Ebooki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Zdrowie, uroda' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Ebooki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Zdrowie, uroda', 'Zdrowie-uroda', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Poradniki' and m.NameForDisplay like 'Ebooki'));


--BookCategory Ebooki/Ebooki dla dzieci
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Literatura dla dzieci' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Ebooki dla dzieci' and m.NameForDisplay like 'Ebooki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Literatura dla dzieci', 'Literatura-dla-dzieci', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Ebooki dla dzieci' and m.NameForDisplay like 'Ebooki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Lektury szkolne' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Ebooki dla dzieci' and m.NameForDisplay like 'Ebooki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Lektury szkolne', 'Lektury-szkolne', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Ebooki dla dzieci' and m.NameForDisplay like 'Ebooki'));
if not exists(select NameForDisplay, SubMainCategoryId from BookCategory where NameForDisplay like 'Podręczniki' and SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Ebooki dla dzieci' and m.NameForDisplay like 'Ebooki'))
insert into BookCategory(NameForDisplay, Name, SubMainCategoryId) values('Podręczniki', 'Podreczniki', (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Ebooki dla dzieci' and m.NameForDisplay like 'Ebooki'));