﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navislamia.Database.Entities
{
    public class MonsterBase
    {
        public int ID;
        
        public int MonsterGroup;

        public int MonsterType;

        public int Race;

        public int Group;

        public int TransformLevel;

        public int Level;

        public float Size;

        public float Scale;

        public int WalkType;

        public int VisibleRange;

        public int ChaseRange;

        public int MagicType;

        public int AttackType;

        public int HP;

        public int MP;

        public int AttackPoint;

        public int MagicPoint;

        public int Defense;

        public int MagicDefense;

        public int AttackSpeed;

        public int AttackSpeedType;

        public int CastingSpeed;

        public int Accuracy;

        public int Avoid;

        public int MagicAccuracy;

        public int MagicAvoid;

        public int TamingCode;
        
        public float TamingPercentage;

        public int Exp, Exp2;

        public int JP, JP2;

        public int StatID;

        public int Ability;

        public int WalkSpeed;

        public int RunSpeed;

        public float AttackRange;

        public float HidesenseRange;

        public int FightType;

        public List<MonsterSkillTrigger> TriggerList;
        public int GoldDropPercentage;

        public int GoldMin, GoldMax, GoldMin2, GoldMax2;
        public int ChaosDropPercentage;

        public int ChaosMin, ChaosMax, ChaosMin2, ChaosMax2;

        public int DropLinkID;

        public MonsterItemDrop ItemDropList;

        public int SkillLinkID;

        public MonsterSkill SkillInfoList;

        public string ScriptOnDead;
    }
}
