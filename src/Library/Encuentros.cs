namespace Library;

public class Encounters
{
    private List<ICharacter> heroes;
    private List<Enemigo> enemigos;

    public Encounters(List<ICharacter> heroes, List<Enemigo> enemigos)
    {
        this.heroes = heroes;
        this.enemigos = enemigos;
    }

    public void DoEncounter()
    {
        bool hayEnemigosVivos = true;
        bool hayHeroesVivos = true;
        while (hayHeroesVivos && hayEnemigosVivos)
        {
            int totalHeroes = heroes.Count;
            int contador = 0;

            for (int i = 0; i < enemigos.Count; i++)
            {
                Enemigo enemigo = enemigos[i];
                if (enemigo.Health > 0)
                {
                    ICharacter objetivo = heroes[contador % totalHeroes];

                    if (objetivo.Health > 0)
                    {
                        enemigo.Attack(objetivo);
                    }

                    contador++;
                }
            }
            
            hayHeroesVivos = false;
            for (int i = 0; i < heroes.Count; i++)
            {
                if (heroes[i].Health > 0)
                {
                    hayHeroesVivos = true;
                }
            }

            if (!hayHeroesVivos)
            {
                hayEnemigosVivos = false; 
            }
            else
            {
                for (int i = 0; i < heroes.Count; i++)
                {
                    ICharacter heroe = heroes[i];

                    if (heroe.Health > 0)
                    {
                        for (int j = 0; j < enemigos.Count; j++)
                        {
                            Enemigo enemigo = enemigos[j];

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
                
                hayEnemigosVivos = false;
                for (int i = 0; i < enemigos.Count; i++)
                {
                    if (enemigos[i].Health > 0)
                    {
                        hayEnemigosVivos = true;
                    }
                }
                
                for (int i = 0; i < heroes.Count; i++)
                {
                    ICharacter heroe = heroes[i];

                    if (heroe.Health > 0 && heroe.VictoryPoints >= 5)
                    {
                        heroe.Heal();
                        heroe.VictoryPoints = 0;
                    }
                }
            }
        }
    }
}