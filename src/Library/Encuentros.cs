namespace Library;

public class Encuentros
{
    private List<ICharacter> heroes;
    private List<Enemigo> enemigos;

    public Encuentros(List<ICharacter> heroes, List<Enemigo> enemigos)
    {
        this.heroes = heroes;
        this.enemigos = enemigos;
    }

    public void DoEncounter()
    {
        bool hayHeroesVivos = true;
        bool hayEnemigosVivos = true;

        while (hayHeroesVivos && hayEnemigosVivos)
        {
            AtaqueEnemigos();

            hayHeroesVivos = true;
            if (!hayHeroesVivos)
            {
                hayEnemigosVivos = false;
            }
            else
            {
                AtaqueHeroes();

                hayEnemigosVivos = true;
            }
        }
    }

    private void AtaqueEnemigos()
    {
        int totalHeroes = heroes.Count;
        int i = 0;

        for (int e = 0; e < enemigos.Count; e++)
        {
            var enemigo = enemigos[e];
            if (enemigo.Health > 0)
            {
                var objetivo = heroes[i % totalHeroes];
                if (objetivo.Health > 0)
                {
                    enemigo.Attack(objetivo);
                }

                i++;
            }
        }
    }

    private void AtaqueHeroes()
    {
        for (int h = 0; h < heroes.Count; h++)
        {
            var heroe = heroes[h];
            if (heroe.Health > 0)
            {
                for (int k = 0; k < enemigos.Count; k++)
                {
                    var enemigo = enemigos[k];
                    if (enemigo.Health > 0)
                    {
                        int vidaAntes = enemigo.Health;
                        heroe.Attack(enemigo);

                        if (enemigo.Health <= 0 && vidaAntes > 0)
                        {
                            heroe.VictoryPoints += enemigo.VictoryPoints;
                            enemigo.VictoryPoints = 0;
                        }
                    }
                }
            }
        }
    }
}