using System;
using System.Collections.Generic;
using System.Text;

namespace BANGReader.Core.Data
{
    public class BangWorld
    {
        // Age of Mythology - Version 123
        // Age of Empires 3 - Version 290
        // Age of Empires Online - Version 310
        public int Version { get; set; } = 0;

        // Sub Versions
        public int UnitGroupVersion { get; set; } = 0;
        public int UnitToBeTaskedVersion { get; set; } = 0;
        public int SquadVersion { get; set; } = 0;
        public int WorkingEntityVersion { get; set; } = 0;
        public int ResourceInventoryVersion { get; set; } = 0; // sub_257560
        public int PathMoveDataVersion { get; set; } = 0; // sub_304E70
        public int UnitBuildActionVersion { get; set; } = 0; // sub_509250
        public int UnitDeathActionVersion { get; set; } = 0; // sub_510060
        public int Unknown01Version { get; set; } = 0; // sub_538D20
        public int UnitGatherActionVersion { get; set; } = 0; // sub_518180
        public int UnitAttackActionVersion { get; set; } = 0; // sub_4FEBC0
        public int UnitHuntingActionVersion { get; set; } = 0; // sub_525E40
        public int UnitIdleActionVersion { get; set; } = 0; // sub_526DC0
        public int UnitMoveActionVersion { get; set; } = 0; // sub_52ABD0
        public int UnitMoveByGroupActionVersion { get; set; } = 0; // sub_52B660

        public int UnknownNoRef7Version { get; set; } = 0;
        public int UnknownNoRef8Version { get; set; } = 0;
        public int UnknownNoRef9Version { get; set; } = 0;
        public int UnitTrainActionVersion { get; set; } = 0;
        public int UnitExploreActionVersion { get; set; } = 0;
        public int UnknownNoRef10Version { get; set; } = 0;
        public int UnknownNoRef11Version { get; set; } = 0;
        public int UnitSacrificeActionVersion { get; set; } = 0;
        public int UnitHealActionVersion { get; set; } = 0;
        public int UnitAIVersion { get; set; } = 0;
        public int SquadAIVersion { get; set; } = 0;
        public int UnknownNoRef15Version { get; set; } = 0;
        public int NoName16Version { get; set; } = 0;
        public int UnknownConflict17Version { get; set; } = 0;
        public int NoName18Version { get; set; } = 0;
        public int NoName19Version { get; set; } = 0;
        public int NoName20Version { get; set; } = 0;
        public int NoName21Version { get; set; } = 0;
        public int UnknownNoRef22Version { get; set; } = 0;
        public int BUnitActionVersion { get; set; } = 0;
        public int UnknownNoRef24Version { get; set; } = 0;
        public int UnknownMultiple25Version { get; set; } = 0;
        public int EntityVersion { get; set; } = 0;
        public int UnitVersion { get; set; } = 0;
        public int BuildingDataVersion { get; set; } = 0;
        public int CommandManagerVersion { get; set; } = 0;
        public int CommandVersion { get; set; } = 0;
        public int WorkCommandVersion { get; set; } = 0;
        public int ResearchCommandVersion { get; set; } = 0;
        public int TrainCommandVersion { get; set; } = 0;
        public int BuildCommandVersion { get; set; } = 0;
        public int SetGatherPointCommandVersion { get; set; } = 0;
        public int CancelBuildingQueueItemCommandVersion { get; set; } = 0;
        public int CreateUnitCommandVersion { get; set; } = 0;
        public int DeleteUnitCommandVersion { get; set; } = 0;
        public int AddResourceCommandVersion { get; set; } = 0;
        public int UnknownNoRef31Version { get; set; } = 0;
        public int StopCommandVersion { get; set; } = 0;
        public int CinematicCommandVersion { get; set; } = 0;
        public int SpecialPowerCommandVersion { get; set; } = 0;
        public int MarketCommandVersion { get; set; } = 0;
        public int EnterCommandVersion { get; set; } = 0;
        public int UnknownNoRef32Version { get; set; } = 0;
        public int PathVersion { get; set; } = 0;
        public int MovementVersion { get; set; } = 0;
        public int PauseCommandVersion { get; set; } = 0;
        public int TributeCommandVersion { get; set; } = 0;
        public int BallisticVersion { get; set; } = 0;
        public int UnitSubGroupVersion { get; set; } = 0;
        public int UnknownMultiple37Version { get; set; } = 0;
        public int UnitActionVersion { get; set; } = 0;
        public int UnitHPCommandVersion { get; set; } = 0;
        public int UnitOrientationCommandVersion { get; set; } = 0;
        public int TransformCommandVersion { get; set; } = 0;
        public int UnitTeleportCommandVersion { get; set; } = 0;
        public int UnitStanceCommandVersion { get; set; } = 0;
        public int PlayerRelationCommandVersion { get; set; } = 0;
        public int FillPlayerArmyCommandVersion { get; set; } = 0;
        public int UnitTownBellCommandVersion { get; set; } = 0;
        public int ExploreCommandVersion { get; set; } = 0;
        public int PlayAnimationCommandVersion { get; set; } = 0;
        public int UnitDynamicDataVersion { get; set; } = 0;
        public int AdjustArmyCommandVersion { get; set; } = 0;
        public int RepairCommandVersion { get; set; } = 0;
        public int EmpowerCommandVersion { get; set; } = 0;
        public int StatInfoCommandVersion { get; set; } = 0;
        public int FormationCommandVersion { get; set; } = 0;
        public int PlayerChatCommandVersion { get; set; } = 0;
        public int UnknownNoRef40Version { get; set; } = 0;
        public int DamageVersion { get; set; } = 0;
        public int PlayerDataCommandVersion { get; set; } = 0;
        public int UnknownNoRef42Version { get; set; } = 0;
        public int EjectCommandVersion { get; set; } = 0;
        public int AgeManagerVersion { get; set; } = 0;
        public int AgeVersion { get; set; } = 0;
        public int UnknownMultiple45Version { get; set; } = 0;
        public int UnitLimberActionVersion { get; set; } = 0;
        public int UnitBroadsideAttackActionVersion { get; set; } = 0;
        public int UnitKnockoutActionVersion { get; set; } = 0;
        public int UnknownMultiple46Version { get; set; } = 0;
        public int SubCivCommandVersion { get; set; } = 0;
        public int UnknownNoRef47Version { get; set; } = 0;
        public int UnitAbilityActionVersion { get; set; } = 0;
        public int UnitRailroadActionVersion { get; set; } = 0;
        public int SquadCommandVersion { get; set; } = 0;
        public int UnknownNoRef48Version { get; set; } = 0;
        public int UnknownNoRef49Version { get; set; } = 0;
        public int UnitPlantFlagActionVersion { get; set; } = 0;
        public int UnitFindNewWorldActionVersion { get; set; } = 0;
        public int UnknownNoRef50Version { get; set; } = 0;
        public int UnitMaintainActionVersion { get; set; } = 0;
        public int UnitBoatManagerVersion { get; set; } = 0;
        public int UnknownConflict53Version { get; set; } = 0;
        public int UnknownNoRef54Version { get; set; } = 0;
        public int UnitActionVersion_2 { get; set; } = 0;
        public int UnknownNoRef56Version { get; set; } = 0;
        public int UnknownNoRef57Version { get; set; } = 0;
        public int UnknownNoRef58Version { get; set; } = 0;
        public int UnknownNoRef59Version { get; set; } = 0;
        public int UnitLikeBonusModifyActionVersion { get; set; } = 0;
        public int UnitDanceBonusActionVersion { get; set; } = 0;
        public int UnknownNoRef61Version { get; set; } = 0;
        public int UnknownNoRef62Version { get; set; } = 0;
        public int UnknownNoRef63Version { get; set; } = 0;
        public int UnknownNoRef64Version { get; set; } = 0;
        public int UnknownNoRef65Version { get; set; } = 0;
        public int UnitOverrideAnimationActionVersion { get; set; } = 0;
        public int UnknownNoRef66Version { get; set; } = 0;
        public int UnknownNoRef67Version { get; set; } = 0;
        public int UnknownNoRef68Version { get; set; } = 0;
        public int UnknownNoRef69Version { get; set; } = 0;
        public int UnknownNoRef70Version { get; set; } = 0;
        public int UnitCommandResearchActionVersion { get; set; } = 0;
        public int UnknownNoRef71Version { get; set; } = 0;

        public string ScenarioType { get; set; } = "";
        public string MapCode { get; set; } = "";

        public bool Unk75C4 { get; set; } = false;
        public bool Unk75C5 { get; set; } = false;

        public int ScenarioTypeNum { get; set; } = 0; // Different values if player is in home city or in quest

        public int Unk1BC { get; set; } = 0;
        public int Unk1C0 { get; set; } = 0;

        public bool UseTerrainHeightLimits { get; set; } = false;
        public bool OceanReveal { get; set; } = false;

        public int Unk64 { get; set; } = 0;
        public int PlayerCount { get; set; } = 0;

    }
}
