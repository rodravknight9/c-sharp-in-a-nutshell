using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace csharp_in_a_nutshell._19_Reflection_and_Metadata
{
    internal class Reflection
    {
    }

    public class Monster : Enemy
    {
        public override EnemyType enemyType { get { return EnemyType.Monster; } }

        public override int Health { get; set; } = 100;

        public override void Attack()
        {
            Console.WriteLine("The monster attacks with its claws");
        }

        public void GainHealth()
        {
            Health += 1;
            Console.WriteLine($"The monster has gained health: {Health}");
        }
    }

    public class Knight : Enemy
    {
        public override EnemyType enemyType { get { return EnemyType.Monster; } }

        public override int Health { get; set; } = 50;

        public Knight()
        {
            Console.WriteLine($"{GetType().GetProperty("Health").Name}: {GetType().GetProperty("Health").GetValue(this)}");
        }

        public override void Attack()
        {
            Console.WriteLine("The monster attacks with his sword");
        }
    }

    public class TIEFighter : SpaceshipEnemy
    {
        public override EnemyType enemyType { get { return EnemyType.Monster; } }

        public override int Health { get; set; } = 100;

        public override void Attack()
        {
            Console.WriteLine("The monster attacks with its claws");
        }

        public void GainHealth()
        {
            Health += 1;
            Console.WriteLine($"The monster has gained health: {Health}");
        }
    }

    public abstract class Enemy : IEnemy
    {
        public abstract EnemyType enemyType { get; }

        public abstract int Health { get; set; }

        public virtual void Attack()
        {
            Console.WriteLine("The enemy attacks");
        }
    }

    public abstract class SpaceshipEnemy : IEnemy
    {
        public abstract EnemyType enemyType { get; }

        public abstract int Health { get; set; }

        public virtual void Attack()
        {
            Console.WriteLine("The spaceship attacks");
        }
    }

    public interface IEnemy
    {
        public EnemyType enemyType { get; }

        public int Health { get; set; }

        public void Attack();
    }

    public enum EnemyType
    { 
        Monster,
        Knight
    }

    public class Fight
    {
        private readonly IEnemy _enemy;

        public Fight(IEnemy enemy)
        {
            _enemy = enemy; 
        }

        public void Start() 
        {
            switch (_enemy.enemyType)
            {
                
                case EnemyType.Knight:
                    Knight knight = new Knight();
                    knight.Attack();
                    break;

                case EnemyType.Monster:
                    Monster monster = new Monster();
                    monster.Attack();
                    monster.GainHealth();
                    break;
            }
        }
    }

    public class BetterFight
    { 
        private readonly IEnemy _enemy;
        public BetterFight(IEnemy enemy)
        {
            _enemy = enemy;
        }

        public void Start() 
        {
            _enemy.Attack();

            var enemyType = _enemy.GetType();

            //-- homework
            var parentClass = enemyType.BaseType;

            MethodInfo specialMovementInfo = enemyType.GetMethod("GainHealth");

            if (specialMovementInfo != null && parentClass == typeof(Enemy))
            { 
                object enemyDynamicInstance = Activator.CreateInstance(enemyType, null);
                specialMovementInfo.Invoke(enemyDynamicInstance, null);
            }
        }
    }


    public class ReflectionTest
    {
        public void SomeMethod()
        {
            Console.WriteLine("This is a method");
        }
    }
}
