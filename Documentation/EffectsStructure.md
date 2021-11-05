# Scénario utilisateur : structure des effets

Avant cela, plusieurs objets :
- Effect : Scriptable Object qui est là pour le seul but d'être affiché
- Planet : ScriptableObject comprenant les infos de la planète, mais aussi le gameObject à instancier

Pour implémenter un effet :
1. Créer l'actif et le passif sous la forme de scripts
2. Créer un gameobject planète contenant les deux scripts
3. Créer l'actif et le passif en Scriptable Object (Effect)
4. Créer le Scriptable Object Planet et y assigner les Effect
5. Lorsque la planète est instanciée, voir si c'est en attaque et en défense
    - Si c'est en défense, désactiver l'actif
    - Si c'est en attaque, désactiver le passif