
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Library;

public class Encounter
{
    private List<Heroes> heroes;
    private List<Enemigo> enemigos;

    public Encounter(List<Heroes> heroes, List<Enemigo> enemigos)
    {
        this.heroes = heroes;
        this.enemigos = enemigos;
    }


    public string DoEncounter()
    {
        var log = new StringBuilder();

        while (heroes.Any(h => h.Health > 0) && enemigos.Any(e => e.Health > 0))
        {
            // 1. Enemigos atacan primero
            var vivosHeroes = heroes.Where(h => h.Health > 0).ToList();
            var vivosEnemigos = enemigos.Where(e => e.Health > 0).ToList();

            for (int i = 0; i < vivosEnemigos.Count; i++)
            {
                var objetivoHeroe = vivosHeroes[i % vivosHeroes.Count];
                string resultado = vivosEnemigos[i].Attack(objetivoHeroe);
                log.AppendLine($"{vivosEnemigos[i].Name} atacó a {objetivoHeroe.Name}: {resultado}");
            }

            // 2. Héroes sobrevivientes atacan a todos los enemigos
            vivosHeroes = heroes.Where(h => h.Health > 0).ToList();
            vivosEnemigos = enemigos.Where(e => e.Health > 0).ToList();

            foreach (var heroe in vivosHeroes)
            {
                foreach (var enemigo in vivosEnemigos)
                {
                    if (enemigo.Health > 0)
                    {
                        string resultado = heroe.Attack(enemigo);
                        log.AppendLine($"{heroe.Name} atacó a {enemigo.Name}: {resultado}");
                        if (enemigo.Health <= 0)
                        {
                            log.AppendLine($"{heroe.Name} derrotó a {enemigo.Name} y ganó {enemigo.VictoryPoints} VP (Total: {heroe.VictoryPoints})");
                            if (heroe.VictoryPoints >= 5)
                            {
                                string healMsg = heroe.Heal();
                                log.AppendLine($"{heroe.Name} se curó: {healMsg}");
                            }
                        }
                    }
                }
            }
        }

        return log.ToString();
    }
}
