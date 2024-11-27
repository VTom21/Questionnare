using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Questionnare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            List<string> questions = new List<string>
{
    // Történelem
    "1. Mikor ért véget az első világháború?\nA. 1914\nB. 1918\nC. 1923\nD. 1905\nHelyes válasz: B. 1918",
    "2. Ki találta fel a nyomtatott könyvet mozgatható betűkkel?\nA. Isaac Newton\nB. Johannes Gutenberg\nC. Leonardo da Vinci\nD. Martin Luther\nHelyes válasz: B. Johannes Gutenberg",
    "3. Melyik országot érte Pearl Harbor támadása a második világháború alatt?\nA. Kanada\nB. Nagy-Britannia\nC. Egyesült Államok\nD. Japán\nHelyes válasz: C. Egyesült Államok",
    "4. Melyik birodalom építette a híres Machu Picchu-t?\nA. Azteka\nB. Maja\nC. Inka\nD. Római\nHelyes válasz: C. Inka",
    "5. Melyik csata jelentette Napóleon végső vereségét?\nA. Trafalgari csata\nB. Borogyinói csata\nC. Leipzigi csata\nD. Waterlooi csata\nHelyes válasz: D. Waterlooi csata",
    "6. Mikor fedezte fel Amerika partjait Kolumbusz Kristóf?\nA. 1492\nB. 1500\nC. 1498\nD. 1486\nHelyes válasz: A. 1492",
    "7. Melyik város volt az Oszmán Birodalom fővárosa a 15. századtól?\nA. Ankara\nB. Isztambul (Konstantinápoly)\nC. Athén\nD. Damaszkusz\nHelyes válasz: B. Isztambul (Konstantinápoly)",
    "8. Melyik ország kezdte meg a reformációt?\nA. Franciaország\nB. Németország\nC. Olaszország\nD. Spanyolország\nHelyes válasz: B. Németország",
    "9. Mikor volt a francia forradalom kezdete?\nA. 1789\nB. 1776\nC. 1804\nD. 1765\nHelyes válasz: A. 1789",
    "10. Ki volt a mongol birodalom alapítója?\nA. Kubiláj kán\nB. Dzsingisz kán\nC. Timur Lenk\nD. Attila\nHelyes válasz: B. Dzsingisz kán",
    "11. Melyik híres szobrot készítette Michelangelo?\nA. Dávid\nB. Milói Vénusz\nC. Szamothrakéi Niké\nD. Pietà\nHelyes válasz: A. Dávid",
    "12. Mikor omlott össze a Nyugatrómai Birodalom?\nA. Kr. u. 395\nB. Kr. u. 476\nC. Kr. u. 410\nD. Kr. u. 509\nHelyes válasz: B. Kr. u. 476",
    "13. Melyik ország vezette az ipari forradalmat a 18. században?\nA. Franciaország\nB. Németország\nC. Nagy-Britannia\nD. Egyesült Államok\nHelyes válasz: C. Nagy-Britannia",
    "14. Melyik esemény vezette be a hidegháború időszakát?\nA. Marshall-terv bejelentése\nB. Németország kettéosztása\nC. A Berlini fal építése\nD. A második világháború vége\nHelyes válasz: D. A második világháború vége",
    "15. Melyik ország lett az első a világon, amely űrhajóst küldött az űrbe?\nA. Egyesült Államok\nB. Szovjetunió\nC. Kína\nD. Franciaország\nHelyes válasz: B. Szovjetunió",
    "16. Mikor kezdődött a hidegháború?\nA. 1947\nB. 1939\nC. 1953\nD. 1962\nHelyes válasz: A. 1947",
    "17. Melyik történelmi személy írta meg a „Kommunista kiáltványt”?\nA. Friedrich Engels\nB. Karl Marx\nC. Lenin\nD. Joseph Stalin\nHelyes válasz: B. Karl Marx",
    "18. Ki volt Nagy Sándor tanítója?\nA. Szókratész\nB. Platón\nC. Arisztotelész\nD. Diogenész\nHelyes válasz: C. Arisztotelész",
    "19. Melyik nép hajtotta végre a híres „tengeri népek” invázióit az ókori Mediterráneumban?\nA. Föníciaiak\nB. Hetiták\nC. Tengeri népek\nD. Görögök\nHelyes válasz: C. Tengeri népek",
    "20. Melyik birodalom uralkodott az ókori Egyiptomban II. Ramszesz idején?\nA. Újbirodalom\nB. Középbirodalom\nC. Óbirodalom\nD. Perzsa Birodalom\nHelyes válasz: A. Újbirodalom",
    "21. Ki alapította Rómát a legenda szerint?\nA. Julius Caesar\nB. Augustus\nC. Romulus és Remus\nD. Hannibál\nHelyes válasz: C. Romulus és Remus",
    "22. Mikor érte el a Hold felszínét az Apollo 11?\nA. 1965\nB. 1969\nC. 1972\nD. 1967\nHelyes válasz: B. 1969",
    "23. Melyik városban található a Taj Mahal?\nA. Delhi\nB. Agra\nC. Jaipur\nD. Mumbai\nHelyes válasz: B. Agra",
    "24. Melyik évben kezdődött a második világháború?\nA. 1937\nB. 1938\nC. 1939\nD. 1940\nHelyes válasz: C. 1939",
    "25. Ki volt az Egyesült Államok első elnöke?\nA. Thomas Jefferson\nB. Abraham Lincoln\nC. George Washington\nD. John Adams\nHelyes válasz: C. George Washington",

    // Fizika
    "1. Mi az SI alapegysége az időnek?\nA. Perc\nB. Óra\nC. Másodperc\nD. Nap\nHelyes válasz: C. Másodperc",
    "2. Milyen sebességgel terjed a fény vákuumban?\nA. 300 km/s\nB. 300 000 km/s\nC. 150 000 km/s\nD. 3 000 000 km/s\nHelyes válasz: B. 300 000 km/s",
    "3. Melyik részecske található az atommagban?\nA. Elektron\nB. Proton\nC. Neutrínó\nD. Foton\nHelyes válasz: B. Proton",
    "4. Mi az energia mértékegysége az SI-rendszerben?\nA. Watt\nB. Joule\nC. Newton\nD. Pascal\nHelyes válasz: B. Joule",
    "5. Ki fogalmazta meg a gravitációs törvényt?\nA. Albert Einstein\nB. Galileo Galilei\nC. Isaac Newton\nD. James Clerk Maxwell\nHelyes válasz: C. Isaac Newton",
    "6. Mi az elektromos áramerősség mértékegysége?\nA. Volt\nB. Ohm\nC. Amper\nD. Joule\nHelyes válasz: C. Amper",
    "7. Mi a hőmérséklet mértékegysége az SI-rendszerben?\nA. Celsius\nB. Fahrenheit\nC. Kelvin\nD. Rankine\nHelyes válasz: C. Kelvin",
    "8. Miért felelős a Lorentz-erő?\nA. Gravitációs kölcsönhatás\nB. Elektromágneses kölcsönhatás\nC. Nukleáris kölcsönhatás\nD. Mechanikai kölcsönhatás\nHelyes válasz: B. Elektromágneses kölcsönhatás",
    "9. Melyik felfedezés vezetett a kvantummechanika elméletéhez?\nA. Rutherford kísérlete\nB. Planck sugárzási törvénye\nC. Galileo kísérletei\nD. Heisenberg elmélete\nHelyes válasz: B. Planck sugárzási törvénye",
    "10. Mi az Ohm törvénye?\nA. I = V/R\nB. P = V*I\nC. E = mc^2\nD. F = ma\nHelyes válasz: A. I = V/R",
    "11. Melyik a legerősebb ismert kölcsönhatás?\nA. Elektromágneses\nB. Gravitációs\nC. Gyenge kölcsönhatás\nD. Erős kölcsönhatás\nHelyes válasz: D. Erős kölcsönhatás",
    "12. Mi az idődilatáció jelensége?\nA. Az idő lelassul, ha valaki gyorsan mozog\nB. Az idő felgyorsul, ha valaki gyorsan mozog\nC. Az idő azonos sebességgel telik mindenhol\nD. Az idő megszűnik létezni\nHelyes válasz: A. Az idő lelassul, ha valaki gyorsan mozog",
    "13. Mi a tömeg mértékegysége az SI-rendszerben?\nA. Kilogramm\nB. Gram\nC. Tonna\nD. Dekagramm\nHelyes válasz: A. Kilogramm",
    "14. Mi a hullámhossz mértékegysége?\nA. Méter\nB. Hertz\nC. Joule\nD. Coulomb\nHelyes válasz: A. Méter",
    "15. Mi a fénysebesség a vákuumban?\nA. 300 000 m/s\nB. 3 000 000 m/s\nC. 300 000 km/s\nD. 30 000 km/s\nHelyes válasz: C. 300 000 km/s"
};

        }
    }
}
