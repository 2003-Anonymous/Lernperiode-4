# Lern-Periode 4

14.2 bis 4.4

## Grob-Planung

Meine Noten sind sehr gut und ich habe alle Module verstanden. In dieser Lernperiode möchte ich ein Towerdefense game in Winforms programmieren, um noch mehr über Objekte zu lernen. Ich weiss noch nicht ob man das so mit Grafiken umsetzten kann, aber das werde ich im Wegwerfprojekt herausfinden.

## 14.2: Explorativer Wegwerf-Prototyp

- [ ] Eine Startseite erstellen, wo man das Spiel starten kann.
- [ ] Ein Forms für das erste Level erstellen und mit dem Start verbinden.

Heute habe ich ein Start-Form gemacht mit einem Buttton, wo man zu ersten map kommt. Von dort kann man mit einem anderen Button wieder zurück. Das Startprogramm wird versteckt, wenn man den Button drückt und wieder sichtbar, wenn man zurückkehrt. Dann habe ich noch etwas mit Texturen probiert, das hat aber noch nicht ganz funktioniert mit dem einfügen und aufrufen.


## 21.2: Explorativer Wegwerf-Prototyp

- [ ] Einen Plan zeichnen, wie das erste Level aussehen soll 
- [ ] Bewegung von Gegnern
- [ ] Türme hinzufügen und Funktion
- [ ] Texturen für Monster hinzufügen
      

Heute habe ich eine Zeichnung von den ersten zwei Levels angefertigt und auch ein wenig was für Objekte und Klassen ich benötige und welche Eigenschaften diese haben. Dann habe ich ein Bild eingefügt und ich konnte dieses auch bewegen. Doch als ich programmiert habe, dass immer wenn ich die Taste P drücke, ein Objekt erstellt wird mit einem bild und sich das nach links bewegt, hat das nicht funktioniert und ich konnte das Problem noch nicht lösen. Dabei habe ich ausversehen irgendetwas gelöscht und dann hat mein Forms nicht mehr funktioniert. Das zu lösen hätte sich nicht mehr gelohnt, da ich sowiso ein neues Projekt nächste Woche anfange, also habe ich einfach noch fast alle Klassen definiert.

## 28.2: Kern-Funktionalität

- [x] Gegner als Objekte erstellen mit Bild
- [x] Programmieren, dass sich die Gegner bewegen
- [ ] Türme hinzufügen, welche auf den nächsten Gegner schiessen können
- [ ] Beim Schiessen werden Objekte erstellt, welche ein Bild haben und sich zu den Gegnern bewegen.

Heute habe ich wieder 2 Forms erstellt und miteinander verbunden. Ein Startform und ein Form für das erste Level. Dann habe ich einen Spawnpunkt hinzugefügt, der begint Gegner zu spawnen nachdem man auf den Startbutton geklickt hat. Im Moment spawnt er 10 Gegner im Abstand von 2 Sekunden. Den Abstand habe ich mit einem Timer festgelegt. Die Gegner laufen einfach von Spawn bis ganz nach links. Dann habe ich noch einen ersten Turm hinzugefügt, der beim betreten des Levels plaziert wird. Dieser Turm kann aber noch nichts.

## 7.3: Kern-Funktionalität

- [x] Programmieren, dass der Turm schiessen kann.
- [x] Hinzufügen, dass die Projektiele auf den nächsten Gegner fliegen.
- [x] Die Projektiele sollen die Gegner töten können.
- [ ] Bauen von mehr Türmen hinzufügen.

Die Kernfunktionalität ist, dass es Gegner hat welche spawnen und sich bewegen können. Diese sollten von Türmen getötet werden können.

Heute habe ich Hinzugefügt, dass der Turm automatisch den nächsten Gegner findet und auf ihn schiesst. Im Moment verfolgen die Projektile den Gegner noch. Ich weiss noch nicht, ob ich das beheben oder so lasses soll. Dann habe ich noch eine Base hinzugefügt, welche nicht von den Gegnern ereicht werden darf.  Wenn ein Gegner die Festung ereicht, wird ihr Leben abgezogen. Die Leben sind in einer Progressbar, welche ich jetzt als Healthbar verwende, sichtbar.

## 14.3: Architektur ausbauen

- [x] Healthbar für die Gegner.
- [ ] Bauen von neuen Türmen ermöglichen.
- [ ] Währung hinzufügen, welche man durch töten von Gegnern bekommt.
- [ ] Anzeige für verbleibende Gegner.

Heute habe ich die Healthbar für die Gegner programmiert. Diese wollte ich in rot, weil ich aber für die Healthbar der Base eine Progressbar genommen habe und diese Standartmässig grün ist und ich die Farbe nicht ändern konnte, musste ich ein neue Customprogressbar erstellen, welche ich dann rot machen konnte. Dann habe ich noch hinzugefügt, dass sich die Healthbar mit dem Gegner mitbewegt und dass sie auch anzeigt, wenn er Schaden genommen hat.

## 21.3: Architektur ausbauen

## 28.3: Auspolieren

## 4.4: Auspolieren & Abschluss

