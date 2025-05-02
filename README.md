# Lern-Periode 4

14.2 bis 4.4

## Grob-Planung

Meine Noten sind sehr gut und ich habe alle Module verstanden. In dieser Lernperiode möchte ich ein Towerdefense game in Winforms programmieren, um noch mehr über Objekte zu lernen. Ich weiss noch nicht, ob man das so mit Grafiken umsetzen kann, aber das werde ich im Wegwerfprojekt herausfinden.

## 14.2: Explorativer Wegwerf-Prototyp

- [x] Eine Startseite erstellen, wo man das Spiel starten kann.
- [x] Ein Forms für das erste Level erstellen und mit dem Start verbinden.

Heute habe ich ein Start-Form gemacht mit einem Buttton, wo man zur ersten map kommt. Von dort kann man mit einem anderen Button wieder zurück. Das Startprogramm wird versteckt, wenn man den Button drückt, und wieder sichtbar, wenn man zurückkehrt. Dann habe ich noch etwas mit Texturen probiert, das hat aber noch nicht ganz funktioniert mit dem einfügen und aufrufen.


## 21.2: Explorativer Wegwerf-Prototyp

- [x] Einen Plan zeichnen, wie das erste Level aussehen soll 
- [x] Bewegung von Gegnern
- [x] Türme hinzufügen und Funktion
- [x] Texturen für Monster hinzufügen
      

Heute habe ich eine Zeichnung von den ersten zwei Levels angefertigt und auch ein wenig was für Objekte und Klassen ich benötige und welche Eigenschaften diese haben. Dann habe ich ein Bild eingefügt und ich konnte dieses auch bewegen. Doch als ich programmiert habe, dass immer, wenn ich die Taste P drücke, ein Objekt erstellt wird, mit einem bild und sich das nach links bewegt, hat das nicht funktioniert und ich konnte das Problem noch nicht lösen. Dabei habe ich ausversehen irgendetwas gelöscht und dann hat mein Forms nicht mehr funktioniert. Das zu lösen hätte sich nicht mehr gelohnt, da ich sowiso ein neues Projekt nächste Woche anfange, also habe ich einfach noch fast alle Klassen definiert.

## 28.2: Kern-Funktionalität

- [x] Gegner als Objekte erstellen, mit Bild
- [x] Programmieren, dass sich die Gegner bewegen
- [x] Türme hinzufügen, welche auf den nächsten Gegner schiessen können
- [x] Beim Schiessen werden Objekte erstellt, welche ein Bild haben und sich zu den Gegnern bewegen.

Heute habe ich wieder 2 Forms erstellt und miteinander verbunden. Ein Startform und ein Form für das erste Level. Dann habe ich einen Spawnpunkt hinzugefügt, der begint Gegner zu spawnen, nachdem man auf den Startbutton geklickt hat. Im Moment spawnt er 10 Gegner im Abstand von 2 Sekunden. Den Abstand habe ich mit einem Timer festgelegt. Die Gegner laufen einfach von Spawn bis ganz nach links. Dann habe ich noch einen ersten Turm hinzugefügt, der beim Betreten des Levels plaziert wird. Dieser Turm kann aber noch nichts.

## 7.3: Kern-Funktionalität

- [x] Programmieren, dass der Turm schiessen kann.
- [x] Hinzufügen, dass die Projektiele auf den nächsten Gegner fliegen.
- [x] Die Projektiele sollen die Gegner töten können.
- [x] Bauen von mehr Türmen hinzufügen.

Die Kernfunktionalität ist, dass es Gegner hat, welche spawnen und sich bewegen können. Diese sollten von Türmen getötet werden können.

Heute habe ich hinzugefügt, dass der Turm automatisch den nächsten Gegner findet und auf ihn schiesst. Im Moment verfolgen die Projektile den Gegner noch. Ich weiss noch nicht, ob ich das beheben oder so lassen soll. Dann habe ich noch eine Base hinzugefügt, welche nicht von den Gegnern ereicht werden darf.  Wenn ein Gegner die Festung ereicht, wird ihr Leben abgezogen. Die Leben sind in einer Progressbar, welche ich jetzt als Healthbar verwende, sichtbar.

## 14.3: Architektur ausbauen

- [x] Healthbar für die Gegner.
- [x] Bauen von neuen Türmen ermöglichen.
- [x] Währung hinzufügen, welche man durch Töten von Gegnern bekommt.

Heute habe ich die Healthbar für die Gegner programmiert. Diese wollte ich in Rot, weil ich aber für die Healthbar der Base eine Progressbar genommen habe und diese Standartmässig grün ist und ich die Farbe nicht ändern konnte, musste ich eine neue Customprogressbar erstellen, welche ich dann rot machen konnte. Dann habe ich noch hinzugefügt, dass sich die Healthbar mit dem Gegner mitbewegt und dass sie auch anzeigt, wenn er Schaden genommen hat.

## 21.3: Architektur ausbauen

- [x] Hinzufügen, dass die Gegner nicht nur geradeaus Laufen
- [x] Mehrere Wellen hinzufügen

Heute habe ich vom letzten Mal noch hinzugefügt, dass Gegner Gold fallen lassen. Mit diesem Gold kann man dann neue Türme bauen. Zu Beginn hat man 50 Gold, mit dem man den ersten Turm kaufen kann. Ich hatte heute noch ein Problem, und zwar sind die Gegner, obwohl sie tot waren, unsichtbar weitergelaufen und haben der Base Schaden gemacht. Das konnte ich zum Glück schnell beheben. Zum Schluss wollte ich noch programmieren, dass die Gegner nicht einfach gerade laufen, sondern sich entlang eines vorgegebenen Pfads bewegen. Das hat aber irgendwie noch nicht funktioniert. Die Gegner laufen jetzt ein wenig nach vorne und bleiben stecken. Zudem habe ich noch ein paar Anpassungen an den Leben, der Geschwindigkeit, dem Schaden und der Feuerrate der Türme vorgenommen, dass es ausgeglichener ist. Dann habe ich noch versucht hinzuzufügen, dass man die Türme verbessern kann. Das hat aber irgendwie nicht ganz geklapt.

## 28.3: Auspolieren

- [x] Einen Hintergrund hinzufügen
- [x] Das Fenster vergrössern oder alles kleiner machen, damit das Spielfeld grösser ist
- [x] Einen Boss am Ende der Wave hizufügen

Heute habe ich alles verkleinert , dass das Feld grösser erscheint. Ich habe auch noch hinzugefügt, dass am Ende der Welle ein Boss erscheint. Dieser sieht anders aus, hat viel mehr Leben und macht mehr Schaden an der Burg, er droppt dafür auch mehr Gold. Ich wollte noch einen Hintergrund hinzufügen, das hat auch geklappt. Dieser war jedoch so unscharf, dass ich ihn lieber wieder entfernt habe. Ich habe nicht herausgefunden, wiso das so ist. Ich habe aber harausgefunden, warum die Gegner nicht weiter auf ihrem Pfad gegangen sind. Und zwar lag das daran, dass sie mehrere Pixel auf einmal gehen. Wenn jetzt aber die Distanz zum nächsten Punkt nicht durch die Anzahl Pixel pro Schritt teilbar ist, bleibt er ein wenig vor diesem Punkt stehen und erreicht ihn somit nie, er kann also nie zum nächsten Punkt gehen und bleibt stecken. Das habe ich gelöst, indem ich durch if überprüfe, ob die Distanz zum Punkt kleiner ist als die Schrittgröse. So funktioniert es. Dann habe ich noch die Türme umgestellt, dass es mit dem Weg Sinn ergibt.

## Beschreibung Projekt
Ich habe ein kleines Towerdefens game in Winforms programmiert. Am Anfang hat man 50 Gold, mit welchem man den ersten Turm bauen kann. Wenn man auf Start klickt, erscheint ein Portal, aus welchem Gegner kommen und am Schluss einer Welle kommt ein kleiner Boss, welcher mehr Leben hat. Durch getötete Gegner erhält man Gold, mit welchem man mehr Türme bauen kann. Die Gegner laufen auf einem Zickzack-Weg zu einer Burg. Wenn ein Gegner die Burg erreicht, bekommt die Burg Schaden.

![Towerdefense_2](https://github.com/user-attachments/assets/90203836-9040-4c4d-a1d9-0da4a182332f)


## Reflexion
Mein Projekt sieht nicht besonders schön aus, aber es funktioniert. Ich konnte die objektorientierte Programmierung gut üben, mit den Türmen, den Projektilen und den Gegnern. Ich habe auch viel darüber gelernt, wie Objekte miteinander kommunizieren und wie ich Informationen von einem Objekt in ein anderes Objekt bekomme. Ausserdem habe ich bei den Projektielen noch gelernt, wie die Position des nächsten Gegners berechnet wird. Ich habe also viel gelernt und diese Periode hat mir viel für Zukünftiige Projekte gebracht. Ich bin eigentlich auch gut vorangekommen, habe aber manchmal ein wenig Zeit benötigt, um herauszufinden, wie ich die Information in ein Objekt bekomme, ohne dass diese Objekte sonst irgendwie eine Verbindung haben.

