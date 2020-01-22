# Blac Jack Game

## Opis

Projekt jest tworzony w języku C# używając Windows Presentation Foundation jako projekt semestralny na przedmiot Programowanie Obiektowe w języku C# na Wyższej Szkole Informatyki I Ekonometrii w Krakowie. BlackJack to prosta gra karciana.

Projekt zawiera:

'BlacJack-Game' - graficzną część aplikacji 
'BJLogic' - logika aplikacji podział na klasy
'BJTests' - testy jednostkowe

## Instrukcja

	Celem gracza w blackjacku jest zebranie łącznej sumy punktów w swoich kartach, która jest 'równa' lub jak 'najbliższa od dołu liczbie 21' – bez jej przekroczenia!

Zebranie powyżej 21 punktów oznacza przegrane rozdanie.

Zebranie dokładnie 21 punktów (tzw. „oczko”) czyli dobranie blackjacka jest od razu zwycięstwem gracza, chyba że krupier też dobierze 21 (remis).

#### Przebieg rozgrywki
```
* Gra zaczyna się od rozadania czterach, kart dwie dla gracza oraz dwie dla krupiera. Podczas rozgrywki można wykonać dwie czynności pobrać kartę albo zpasować. 

* Po zpasowaniu następuje ruch krupiera, który dobiera tak długo aż przebije gracza. 

* Na samym końcy sprawdzana jest wartość kart.
```
#### Punktacja
```
* Karty od dwójki do dziesiątki mają wartość równą numerowi karty.

* Walet, Dama i Król mają wartość równą 10 punktów.

* As ma wartość równą 1 lub 11, w zależności co jest lepsze dla gracza.
```
	
## Technologie

* Microsoft WPF Framework
* Microsoft .NET Framework
	
## Twórcy

[Adam Prodyk](https://github.com/aprocyk) - Lider

[Michał gancarczyk](https://github.com/mgancarczyk)