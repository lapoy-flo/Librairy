Au cas où la base de données ne fonctionne pas !

Pour la créer :

View > Server Explorer
Clic droit sur Data Connections > Add Connection

Server name: (localdb)\v11.0
database name: library

Ensuite déplier la base qui vient de se créer > clic droit Tables > Add Table
Ouvrir le init.sql et executer 
(en cliquant sur "Update" au dessus de la table, puis "Update Database") 
les commandes 1 à 1 et dans l'ordre.

Devrait fonctionner après ça.