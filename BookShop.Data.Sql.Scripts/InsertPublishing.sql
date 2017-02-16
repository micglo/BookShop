if not exists(select * from Publishing where NameForDisplay like 'Literackie')
insert into Publishing(NameForDisplay, Name, [Description])
values('Literackie', 'Literackie',
'Oficyna literacka założona w 1953 roku z siedzibą w centrum Krakowa. Do 2003 roku Wydawnictwo Literackie było przedsiębiorstwem państwowym. Wydawnictwo Literackie specjalizuje się w wydawaniu literatury pięknej, zarówno polskiej jak i zagranicznej. W swojej ofercie ma także książki edukacyjne – słowniki, leksykony i podręczniki z zakresu nauk humanistycznych. Wśród autorów znajdziemy polskich noblistów Wisławę Szymborską i Czesława Miłosza Miłosz oraz innych wybitnych autorów, m.in.: Witolda Gombrowicza, Gustawa Herlinga-Grudzińskiego, Tadeusza Różewicza, Adama Zagajewskiego.

Do grona osób związanych z wydawnictwem należeli również najwybitniejsi znawcy literatury i historii: Michał Głowiński, Maria Janion, Stanisław Barańczak . Najpopularniejszymi seriami Wydawnictwa Literackiego są Lekcja Literatury, Biblioteka Poezji Młodej Polski, Współczesność, Monografie, Leksykon Historii i Kultury Polskiej, a także Pisarze Języka Niemieckiego. Do największych osiągnięć Wydawnictwa Literackiego można zaliczyć wydanie i przygotowanie spuścizny Stanisława Brzozowskiego, Witolda Gombrowicza i Antoniego Kępińskiego, wydanie dzieł Stanisława Lema, a także zbioru „Skrzydlate słowa” pod redakcją Henryka Markiewicza i Andrzeja Romanowskiego.');

if not exists(select * from Publishing where NameForDisplay like 'Prószyński Media')
insert into Publishing(NameForDisplay, Name, [Description])
values('Prószyński Media', 'Proszynski-Media', 
'Polskie wydawnictwo prasowe i książkowe z siedzibą w Warszawie, istniejące od 2002 roku. Pod koniec 2008 roku przejęło działalność wydawnictwa Prószyński i S-ka SA. W październiku 2009 roku doszło do całkowitego połączenia spółek. Głównym udziałowcem jest Mieczysław Prószyński, zaś prezesem Maciej Makowski. Obecnie wydawnictwo zajmuje się już tylko wydawaniem książek. Wydaje literaturę polską i światową, zarówno klasykę, jak i prozę współczesną, literaturę faktu i biografie, kulinaria, książki popularnonaukowe oraz książki dla dzieci i młodzieży. ');

if not exists(select * from Publishing where NameForDisplay like 'W.A.B.')
insert into Publishing(NameForDisplay, Name, [Description])
values('W.A.B.', 'W-A-B.', 
'Wydawnictwo W.A.B. powstało w 1991 roku w Warszawie. Nazwa pochodzi od pierwszych liter imion jego założycieli: Wojciecha Kuhna, Adama Widmańskiego i Beaty Stasińskiej. Obecnie W.A.B. jest częścią Grupy Wydawniczej Foksal. Do największych sukcesów oficyny należy wydawanie współczesnej prozy polskiej, a w niej książki takich nazwisk jak: Jacek Dehnel, Wojciech Kuczok czy Zygmunt Miłoszewski. W.A.B posiada ponadto w swojej ofercie powieści Michela Houellebecqa, Władimira Sorokina, noblistów Elfriede Jelinek, Imre Kertesza i Doris Lessing. Oficyna wydaje także eseje z zakresu nauk humanistycznych (Umberto Eco, Maria Janion, Bruno Bettelheim), kryminały (Henning Mankell), reportaże (Wojciech Jagielski) i książki dla dzieci i młodzieży. W.A.B. wspiera tłumaczy oraz początkujących twórców. Swoje debiuty wydali tam m.in. Mariusz Czubaj, Jacek Dehnel i Wojciech Kuczok.');

if not exists(select * from Publishing where NameForDisplay like 'Świat Książki')
insert into Publishing(NameForDisplay, Name, [Description])
values('Świat Książki', 'Swiat-Ksiazki', 
'Polskie wydawnictwo założone w 1994 roku, z siedzibą w Warszawie. W 2011 roku Świat Książki został sprzedany grupie Weltbild. Dopiero w 2013 roku wyodrębniono odrębną spółkę, w której 100% udziałów zakupiła wrocławska oficyna Bukowy Las. Prezesem spółki jest Zbigniew Czerwiński, a pracami wydawnictwa kieruje Daria Kielan.');

if not exists(select * from Publishing where NameForDisplay like 'Znak')
insert into Publishing(NameForDisplay, Name, [Description])
values('Znak', 'Znak', 
'Społeczny Instytut Wydawniczy Znak powstał w 1959 roku. To jedna z większych polskich instytucji wydawniczych. Siedziba wydawnictwa mieści się w Krakowie. Początkowo było to wydawnictwo skupione wokół miesięcznika literackiego „Znak” i „Tygodnika Powszechnego”(siedziba mieściła się nad redakcją). Z powstawaniem wydawnictwa związek mieli Jerzy Turowicz, Jacek Woźniakowski, ksiądz Józef Tischner, Gustaw Herling-Grudziński i Czesław Miłosz.

Po 1989 roku wydawnictwo Znak rozszerzyło swoją działalność. Siedziba firmy została przeniesiona do zabytkowego Dworku Łowczego. Obecnie wydawnictwo jest określane jako „stajnia noblistów”. Do jego autorów należą m.in. Mario Vargas Llosa, Josif Brodski, J.M. Coetzee, W.H. Auden czy Samuel Beckett.

„Bo kryją skandynawskie mgły Bezczelnie nagi fakt: Dostajesz, bracie, Nobla, gdy Twoim wydawcą Znak” Autorem „Hymnu Znaku” jest Stanisław Barańczak.');

if not exists(select * from Publishing where NameForDisplay like 'Sonia Draga')
insert into Publishing(NameForDisplay, Name, [Description])
values('Sonia Draga', 'Sonia-Draga', 
'Katowickie wydawnictwo założone i kierowane przez Sonię Dragę. W swojej ofercie posiada, wydane we współpracy z Wydawnictwem Albatros, światowe bestsellery. Do tytułów Soni Dragi należą m.in. : „Kod Leonarda da Vinci" i „Anioły i demony" Dana Browna, powieści Jeffreya Eugenidesa („Middlesex") i Edwarda Jonesa („Znany świat"). Zespół Soni Dragi ujawnia swoją filozofię wydawnictwa: „W doborze książek kierujemy się intuicją i własnymi zamiłowaniami. Wybieramy te, które mówią coś ważnego o świecie i nie pozwalają czytelnikom przejść obok siebie obojętnie". ');

if not exists(select * from Publishing where NameForDisplay like 'Novae Res')
insert into Publishing(NameForDisplay, Name, [Description])
values('Novae Res', 'Novae-Res', 
'Wydawnictwo Novae Res powstało w 2007 roku w Gdyni. Oficyna została założona przez Wojciecha Gustowskiego i Krzysztofa Szymańskiego. Nazwa oznacza zmianę, przewrót i rewolucję w publikowaniu treści. Novae Res wydaje przede wszystkim beletrystykę i literaturę popularnonaukową. Łączny nakład to około 240 nowych pozycji rocznie. W 2012 wydawnictwo otrzymało tytuł "Mikroprzedsiębiorcy Roku" w konkursie organizowanym przez Fundację Kronenberga i City Handlowy. Novae Res organizuje ponadto cykliczny konkurs "Literacki Debiut Roku", który wspierany jest przez Ministerstwo Kultury i Dziedzictwa Narodowego. ');

if not exists(select * from Publishing where NameForDisplay like 'WAM')
insert into Publishing(NameForDisplay, Name, [Description])
values('WAM', 'WAM', 
'Wydawnictwo WAM (Wydawnictwo Apostolstwa Modlitwy) - najstarsze polskie wydawnictwo katolickie powstałe w 1872 roku. Zostało założone przez ks. Stanisława Stojałowskiego w Krakowie. Wydawnictwo specjalizuje się w wydawaniu publikacji religijnych. WAM publikuje ponad dwieście nowych książek rocznie, w tym katechizmy, modlitewniki, rozprawy naukowe z zakresu teologii i filozofii, a także książki na temat wiary i duchowości. Do serii wydawniczych należą: "Biblioteka życia duchowego", "Mała biblioteka religii", "Myśl teologiczna". Najważniejszymi dziełami przygotowanymi przez WAM było "Pismo Święte" w tłumaczeniu Jakuba Wujka, "Żywoty Świętych” Piotra Skargi oraz "Ćwiczenia Duchowne" św. Ignacego Loyoli.');

if not exists(select * from Publishing where NameForDisplay like 'Albatros')
insert into Publishing(NameForDisplay, Name, [Description])
values('Albatros', 'Albatros', 
'Albatros to nazwa nieformalnej grupy wydawniczej, którą tworzą obecnie dwie oficyny: Wydawnictwo Albatros Andrzej Kuryłowicz s.c. oraz Wydawnictwo Aleksandra i Andrzej Kuryłowicz s.c. Albatros specjalizuje się we współczesnej beletrystyce i literaturze faktu, a przede wszystkim w przekładach z językach angielskiego, francuskiego i hiszpańskiego. Filozofia wydawnictwa to "najsławniejsi autorzy, najgłośniejsze książki, największe światowe bestsellery".

W 2010 Albatros zadebiutował jako wydawca książek elektronicznych. Jest ponadto jedną z pierwszych oficyn, która zaczęła współpracować z platformami internetowymi. Poza klasycznymi wydaniami książkowymi, wydawnictwo oferuje dużą ofertą audiobooków, w tym powieści czytane przez m.in. Mariana Opanię, Krzysztofa Globisza, Jana Peszka, czy Jacka Rozenka. Do działalności pozawydawniczej należy organizacja jedynej w Polsce nagrody dla tłumaczy literatury naukowej i popularnonaukowej.');

if not exists(select * from Publishing where NameForDisplay like 'Amber')
insert into Publishing(NameForDisplay, Name, [Description])
values('Amber', 'Amber', 
'Wydawnictwo Amber - pierwsze wydawnictwo prywatne w Polsce, które powstało 28 lutego 1989 roku. Zostało założone przez Zbigniewa Fonioka, pracownika naukowego Zakładu Aparatury Mikrofalowej Polskiej Akademii Nauk i grafika Dariusza Chojnackiego. Pierwsza książka została wydana w lipcu 1989 roku w nakładzie 320 000 egzemplarzy. Od 1992 roku wydawnictwem Amber kieruje małżeństwo Zbigniew Foniok i Małgorzata Cebo-Foniok, tłumaczka i krytyk literatury francuskiej, członek Stowarzyszenia Pisarzy Polskich i Stowarzyszenia Tłumaczy Polskich. Wydawnictwo Amber wydawało pod swoim szyldem wiele bestsellerowych powieści. Amber wprowadził autorów najlepszych powieści sensacyjnych, fantastyki, horroru i powieści dla kobiet. Wśród autorów można wymienić chociażby Kena Folletta, Deana Koontza, Danielle Steel czy Ursulę Le Guin. Rok 2014 był przełomowym w historii wydawnictwa. Opublikowano 201 tytułów (w tym 118 nowych tytułów) w nakładzie ponad 930 000 egzemplarzy. Amber nadal z sukcesem publikuje kryminały i wybitną prozę światową, ponadto wypromował nowy gatunek - literaturę dla Młodych Dorosłych (New Adult). W tym nurcie Amber wypromowało między innymi książki "Tylko ty", "Zaczekaj na mnie". Do najpopularniejszych tytułów należą: 6-tomowy cykl Jodi Ellen Malpas "Ten mężczyzna" oraz trylogia "Niezgodna". Obecnie Amber rozszerzyło swoją ofertę wydawniczą o antystresowe kreatywne książki do kolorowania dla dorosłych oraz publikacje na temat praktyki uważności (mindfulness).');

if not exists(select * from Publishing where NameForDisplay like 'Pascal')
insert into Publishing(NameForDisplay, Name, [Description])
values('Pascal', 'Pascal', 
'Pascal to wydawnictwo turystyczne oferujące przewodniki, mapy, książki ilustrowane, atlasy. Posiada ponad 50-procentowy udział w rynku przewodników turystycznych. Jego siedziba znajduje się w Bielsku-Białej. Oficyna ma w swojej ofercie ponad 300 tytułów w różnych seriach, ponad 200 map kartograficznych, atlasy geograficzne, książki ilustrowane i przewodniki kulinarne. Wydawnictwo Pascal przygotowuje także przewodniki na zamówienie.');

if not exists(select * from Publishing where NameForDisplay like 'MD')
insert into Publishing(NameForDisplay, Name)
values('MD', 'MD');

if not exists(select * from Publishing where NameForDisplay like 'Illuminatio')
insert into Publishing(NameForDisplay, Name, [Description])
values('Illuminatio', 'Illuminatio', 
'Nowoczesna i dynamiczna oficyna Nowej Ery – wydawnictwo ILLUMINATIO – otwiera przed Czytelnikami bibliotekę bestsellerów – półek pełnych inspiracji, magii, motywacji, tajemnic i zagadek Wszechświata oraz recept na zdrowe ciało i duszę.

Książki te stanowią narzędzie do rozwoju osobistego, dotarcia do źródła mądrości i kreatywności. Rozwijają rozum dzieci i młodzieży, uszlachetniają i cieszą umysł dorosłego oraz odmładzają ducha starca. Niektóre chce się kosztować – powoli i dokładnie, inne połyka się w całości, by jak najszybciej mądrością oświetlić swoje życie, wzruszeniem napełnić serce i odkryć nowy, nieznany dotąd świat…');

if not exists(select * from Publishing where NameForDisplay like 'Kobiece')
insert into Publishing(NameForDisplay, Name, [Description])
values('Kobiece', 'Kobiece', 
'Wydawnictwo Kobiece - założone przez kobiety wydawnictwo, którego misją jest dostarczenie unikalnych,  niebanalnych i intrygujących książek tworzonych przez kobiety i dedykowanych tylko dla kobiet. Książek, które odpowiedzą na wyzwania współczesnej kobiety, będą niczym drogowskazy umożliwiające rozwiązanie wielu problemów i posłużą za katalizatory zmian, których kobiety – po lekturze książek Wydawnictwa Kobiecego – będą dokonywać więcej i świadomiej.
 
Wydawnictwo Kobiece to także unikalna przestrzeń pełna różnorodnych książek, w których zwierciadle odnajdą się wszystkie kobiety. Każda z nich znajdzie w ofercie wydawnictwa coś, co z pewnością je zainteresuje. Każda znajdzie tu miejsce na chwilę wytchnienia od codziennej rzeczywistości – chwilę przyjemności płynącą z lektury wyjątkowych tekstów, przeznaczonych tylko dla niej.
 
Wydawnictwo Kobiece to także przedsięwzięcie wpisujące się w szeroko zakrojoną, ogólnopolską kampanię społeczną Książka Jest Kobietą. Misją wydawnictwa jest obudzenie w kobietach chęci do czytania, a także zaspokojenia czytelniczych pragnień co bardziej ambitnych miłośniczek literatury. To także przestrzeń promująca swoisty trend na kobiece czytanie i kreująca nową kobietę współczesną – piękną, elegancką, pewną siebie erudytkę, która w sposób zdecydowany przejmuje ster swojego życia, ale niezmiennie z książką u boku.');

if not exists(select * from Publishing where NameForDisplay like 'Jerzy Zięba')
insert into Publishing(NameForDisplay, Name)
values('Jerzy Zięba', 'Jerzy-Zieba');

if not exists(select * from Publishing where NameForDisplay like 'Zysk i S-ka')
insert into Publishing(NameForDisplay, Name, [Description])
values('Zysk i S-ka', 'Zysk-i-S-ka',
'Zysk i S-ka, obecnie jedno z największych wydawnictw w Polsce, powstało w kwietniu 1994 roku, w konsekwencji odejścia Tadeusza Zyska i Aleksandra Szablińskiego z wydawnictwa Rebis.

Oferta wydawnictwa Zysk i S-ka obejmuje literarurę polską i obcą, w tym: książki podróżnicze, historyczne, popularno-naukowe, kryminały, fantasy, science-fiction, poradniki, beletrystykę oraz audiobooki.

Bestsellerowe książki wydawnictwa Zysk i S-ka: seria “Pieśń Lodu i Ognia” George’a R. R. Martina, seria “Bridget Jones” Helen Fielding oraz seria książek dla dzieci “Pan Pierdziołka”. Oprócz tego wydawnictwo wprowadza do sprzedaży między innymi książki Elżbiety Cherezińskiej, J.R.R. Tolkiena, Wojciecha Cejrowskiego, Roberta Jordana, Marion Zimmer Bradley, Małgorzaty Kalicińskiej, Marcina Wolskiego, Jacka Pałkiewicza, Rafała A. Ziemkiewicza.');