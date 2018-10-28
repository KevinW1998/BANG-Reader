using BANGReader.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BANGReader.Core
{
    class BangScenarioReader
    {
        private BangChunkReader chunkReader;


        public BangScenarioReader(BangChunkReader chunkReader)
        {
            this.chunkReader = chunkReader;
        }

        public BangDataHeader ReadHeader()
        {
            BangDataHeader header = new BangDataHeader();

            chunkReader.ReadExpectedTag(0x4742);
            header.FileVersion = chunkReader.ReadInt32();
            header.VersionInformation = header.FileVersion >= 25 ? chunkReader.ReadString() : "Unknown";

            var lenUnkArray = header.FileVersion >= 4 ? chunkReader.ReadInt32() : 0;
            header.UnkCArray = chunkReader.ReadASCIIString(lenUnkArray);

            if (header.FileVersion >= 23)
            {
                int unkLangId = chunkReader.ReadInt32(); // TODO: This is lang id --> would need to load lang xml files
                header.UnkStr = chunkReader.ReadString();
            }

            if (header.FileVersion >= 33)
            {
                header.UnkBool = chunkReader.ReadBoolean();
            }

            return header;
        }

        public BangWorld ReadWorld(bool unkA5)
        {
            BangWorld world = new BangWorld();

            chunkReader.ReadExpectedTag(0x314A);
            world.Version = chunkReader.ReadInt32();
            world.UnitGroupVersion = chunkReader.ReadExpectedTagValue(0x3648);
            world.UnitToBeTaskedVersion = chunkReader.ReadExpectedTagValue(0x374B);
            world.SquadVersion = chunkReader.ReadExpectedTagValue(0x394B);
            world.WorkingEntityVersion = chunkReader.ReadExpectedTagValue(0x3448);
            world.ResourceInventoryVersion = chunkReader.ReadExpectedTagValue(0x3348);
            world.PathMoveDataVersion = chunkReader.ReadExpectedTagValue(0x4147);
            world.UnitBuildActionVersion = chunkReader.ReadExpectedTagValue(0x5246);
            world.UnitDeathActionVersion = chunkReader.ReadExpectedTagValue(0x4E46);
            world.Unknown01Version = chunkReader.ReadExpectedTagValue(0x5654);
            world.UnitGatherActionVersion = chunkReader.ReadExpectedTagValue(0x4C46);
            world.UnitAttackActionVersion = chunkReader.ReadExpectedTagValue(0x4B46);
            world.UnitHuntingActionVersion = chunkReader.ReadExpectedTagValue(0x4746);
            world.UnitIdleActionVersion = chunkReader.ReadExpectedTagValue(0x4546);
            world.UnitMoveActionVersion = chunkReader.ReadExpectedTagValue(0x4346);
            world.UnitMoveByGroupActionVersion = chunkReader.ReadExpectedTagValue(0x354F);

            if(world.Version < 225)
                chunkReader.ReadExpectedTagValue(0x3746);

            world.UnknownNoRef7Version = chunkReader.ReadExpectedTagValue(0x3546);

            if(world.Version >= 309)
                world.UnknownNoRef8Version = chunkReader.ReadExpectedTagValue(0x5645);

            world.UnknownNoRef9Version = chunkReader.ReadExpectedTagValue(0x3346);
            world.UnitTrainActionVersion = chunkReader.ReadExpectedTagValue(0x3146);
            world.UnitExploreActionVersion = chunkReader.ReadExpectedTagValue(0x4145);

            if (world.Version >= 269)
                world.UnitSacrificeActionVersion = chunkReader.ReadExpectedTagValue(0x5653);
            if (world.Version >= 282)
                world.UnknownNoRef11Version = chunkReader.ReadExpectedTagValue(0x5653);
            if (world.Version >= 288)
                world.UnknownNoRef10Version = chunkReader.ReadExpectedTagValue(0x5647);

            if (world.Version >= 310)
                world.UnitHealActionVersion = chunkReader.ReadExpectedTagValue(0x4946);
            else
                world.UnitHealActionVersion = 1;

            world.UnitAIVersion = chunkReader.ReadExpectedTagValue(0x4155);
            world.SquadAIVersion = chunkReader.ReadExpectedTagValue(0x4155);
            world.UnknownNoRef15Version = chunkReader.ReadExpectedTagValue(0x3153);
            world.NoName16Version = chunkReader.ReadExpectedTagValue(0x5653); // Squad task related
            world.UnknownConflict17Version = chunkReader.ReadExpectedTagValue(0x3353); // Squad task related
            world.NoName18Version = chunkReader.ReadExpectedTagValue(0x5653); // Squad task related
            world.NoName19Version = chunkReader.ReadExpectedTagValue(0x5653); // Squad task related
            world.NoName20Version = chunkReader.ReadExpectedTagValue(0x5653); // Squad task related
            world.NoName21Version = chunkReader.ReadExpectedTagValue(0x5653); // Squad task related
            world.UnknownNoRef22Version = chunkReader.ReadExpectedTagValue(0x5654);
            world.BUnitActionVersion = chunkReader.ReadExpectedTagValue(0x4341); // 
            world.UnknownNoRef24Version = chunkReader.ReadExpectedTagValue(0x5641);
            world.UnknownMultiple25Version = chunkReader.ReadExpectedTagValue(0x5645); // Unknown? - sub_1E2E90
            world.EntityVersion = chunkReader.ReadExpectedTagValue(0x314f);
            world.UnitVersion = chunkReader.ReadExpectedTagValue(0x5655);
            world.BuildingDataVersion = chunkReader.ReadExpectedTagValue(0x5656);
            world.CommandManagerVersion = chunkReader.ReadExpectedTagValue(0x314d);
            world.CommandVersion = chunkReader.ReadExpectedTagValue(0x334d);
            world.WorkCommandVersion = chunkReader.ReadExpectedTagValue(0x414d);
            world.ResearchCommandVersion = chunkReader.ReadExpectedTagValue(0x434d);
            world.TrainCommandVersion = chunkReader.ReadExpectedTagValue(0x454d);
            world.BuildCommandVersion = chunkReader.ReadExpectedTagValue(0x474d);
            world.SetGatherPointCommandVersion = chunkReader.ReadExpectedTagValue(0x494d);
            world.CancelBuildingQueueItemCommandVersion = chunkReader.ReadExpectedTagValue(0x4b4d);
            world.CreateUnitCommandVersion = chunkReader.ReadExpectedTagValue(0x5643);
            world.DeleteUnitCommandVersion = chunkReader.ReadExpectedTagValue(0x4d4d);
            world.AddResourceCommandVersion = chunkReader.ReadExpectedTagValue(0x514d);
            world.StopCommandVersion = chunkReader.ReadExpectedTagValue(0x534d);
            world.UnknownNoRef31Version = chunkReader.ReadExpectedTagValue(0x534d); // sub_1626B0
            world.CinematicCommandVersion = chunkReader.ReadExpectedTagValue(0x314e);
            world.SpecialPowerCommandVersion = chunkReader.ReadExpectedTagValue(0x5650);
            world.MarketCommandVersion = chunkReader.ReadExpectedTagValue(0x564d);
            world.EnterCommandVersion = chunkReader.ReadExpectedTagValue(0x5645);

            if(world.Version >= 303)
                world.UnknownNoRef32Version = chunkReader.ReadExpectedTagValue(0x6474);

            world.PathVersion = chunkReader.ReadExpectedTagValue(0x4850);
            world.MovementVersion = chunkReader.ReadExpectedTagValue(0x444d);
            world.PauseCommandVersion = chunkReader.ReadExpectedTagValue(0x5559);
            world.TributeCommandVersion = chunkReader.ReadExpectedTagValue(0x5654); // sub_165AE0
            world.BallisticVersion = chunkReader.ReadExpectedTagValue(0x4442);
            world.UnitSubGroupVersion = chunkReader.ReadExpectedTagValue(0x374a);
            world.UnknownMultiple37Version = chunkReader.ReadExpectedTagValue(0x3848); // UnitAI related?
            world.UnitActionVersion = chunkReader.ReadExpectedTagValue(0x4148);
            world.UnitHPCommandVersion = chunkReader.ReadExpectedTagValue(0x5048);
            world.UnitOrientationCommandVersion = chunkReader.ReadExpectedTagValue(0x524f);
            world.TransformCommandVersion = chunkReader.ReadExpectedTagValue(0x5654);

            if(world.Version < 301)
            {
                chunkReader.ReadExpectedTagValue(0x4147);
                chunkReader.ReadExpectedTagValue(0x4147);
                chunkReader.ReadExpectedTagValue(0x4147);
                chunkReader.ReadExpectedTagValue(0x4147);
                chunkReader.ReadExpectedTagValue(0x4147);
                chunkReader.ReadExpectedTagValue(0x5641);
            }

            world.UnitTeleportCommandVersion = chunkReader.ReadExpectedTagValue(0x474d);
            world.UnitStanceCommandVersion = chunkReader.ReadExpectedTagValue(0x5655);
            world.PlayerRelationCommandVersion = chunkReader.ReadExpectedTagValue(0x5650);
            world.FillPlayerArmyCommandVersion = chunkReader.ReadExpectedTagValue(0x5646);
            world.UnitTownBellCommandVersion = chunkReader.ReadExpectedTagValue(0x5654);
            world.ExploreCommandVersion = chunkReader.ReadExpectedTagValue(0x534d);
            world.PlayAnimationCommandVersion = chunkReader.ReadExpectedTagValue(0x5641);
            world.UnitDynamicDataVersion = chunkReader.ReadExpectedTagValue(0x6365);
            world.AdjustArmyCommandVersion = chunkReader.ReadExpectedTagValue(0x5652);
            world.RepairCommandVersion = chunkReader.ReadExpectedTagValue(0x5652);
            world.EmpowerCommandVersion = chunkReader.ReadExpectedTagValue(0x5645);
            world.StatInfoCommandVersion = chunkReader.ReadExpectedTagValue(0x5653); // sub_169830
            world.FormationCommandVersion = chunkReader.ReadExpectedTagValue(0x5655);
            world.PlayerChatCommandVersion = chunkReader.ReadExpectedTagValue(0x5641);
            world.UnknownNoRef40Version = chunkReader.ReadExpectedTagValue(0x4347);
            world.UnknownNoRef41Version = chunkReader.ReadExpectedTagValue(0x3024);

            if (world.Version < 224)
            {
                chunkReader.ReadExpectedTagValue(0x3224);
                chunkReader.ReadExpectedTagValue(0x3424);
                chunkReader.ReadExpectedTagValue(0x3624);
            }

            world.PlayerDataCommandVersion = chunkReader.ReadExpectedTagValue(0x5650);
            chunkReader.ReadExpectedTagValue(0x4453);
            world.UnknownNoRef42Version = chunkReader.ReadExpectedTagValue(0x5553);

            if(world.Version >= 206)
                world.EjectCommandVersion = chunkReader.ReadExpectedTagValue(0x5645);

            if (world.Version >= 206)
                world.AgeManagerVersion = chunkReader.ReadExpectedTagValue(0x4d41);

            if (world.Version >= 216)
                world.AgeVersion = chunkReader.ReadExpectedTagValue(0x4541);
            else
                world.AgeVersion = 0xFFFF;

            if (world.Version >= 217)
                world.UnknownMultiple45Version = chunkReader.ReadExpectedTagValue(0x3423); // Player related?

            if (world.Version >= 220)
                world.UnitLimberActionVersion = chunkReader.ReadExpectedTagValue(0x694c);

            if(world.Version < 226)
                chunkReader.ReadExpectedTagValue(0x3746);

            if (world.Version >= 220)
                world.UnitBroadsideAttackActionVersion = chunkReader.ReadExpectedTagValue(0x3746);

            if (world.Version >= 227)
                world.UnitKnockoutActionVersion = chunkReader.ReadExpectedTagValue(0x7744);

            if (world.Version < 245)
                chunkReader.ReadExpectedTagValue(0x7157);

            if(world.Version > 233)
                world.UnknownMultiple46Version = chunkReader.ReadExpectedTagValue(0x796d); // BUnitAction related?

            if (world.Version > 235)
                world.SubCivCommandVersion = chunkReader.ReadExpectedTagValue(0x6353);

            if (world.Version < 306)
                chunkReader.ReadExpectedTagValue(0x5762);

            world.UnknownNoRef47Version = chunkReader.ReadExpectedTagValue(0x6d72);

            if (world.Version >= 241)
                world.UnknownNoRef50Version = chunkReader.ReadExpectedTagValue(0x7274);

            if (world.Version >= 238)
                world.UnitFindNewWorldActionVersion = chunkReader.ReadExpectedTagValue(0x774e);
            if (world.Version >= 238)
                world.UnitPlantFlagActionVersion = chunkReader.ReadExpectedTagValue(0x4670);

            if (world.Version >= 240)
                world.UnknownNoRef49Version = chunkReader.ReadExpectedTagValue(0x5267);

            if (world.Version >= 246)
                world.UnknownNoRef48Version = chunkReader.ReadExpectedTagValue(0x4169);

            if (world.Version >= 249)
                world.SquadCommandVersion = chunkReader.ReadExpectedTagValue(0x7173);

            if (world.Version >= 253)
                world.UnitRailroadActionVersion = chunkReader.ReadExpectedTagValue(0x5652);

            if (world.Version >= 254)
                world.UnitAbilityActionVersion = chunkReader.ReadExpectedTagValue(0x4746);

            if (world.Version >= 256)
                world.UnitMaintainActionVersion = chunkReader.ReadExpectedTagValue(0x616d);

            if (world.Version >= 260)
                world.UnitBoatManagerVersion = chunkReader.ReadExpectedTagValue(0x4946);

            if (world.Version >= 261)
                world.UnknownConflict53Version = chunkReader.ReadExpectedTagValue(0x396f); // Squad related?

            if (world.Version >= 262)
                world.UnknownNoRef71Version = chunkReader.ReadExpectedTagValue(0x5266);

            if (world.Version >= 265)
                world.UnitCommandResearchActionVersion = chunkReader.ReadExpectedTagValue(0x3346);

            if (world.Version >= 266)
                world.UnknownNoRef70Version = chunkReader.ReadExpectedTagValue(0x5643);

            if (world.Version >= 276)
                world.UnknownNoRef69Version = chunkReader.ReadExpectedTagValue(0x5652);

            if (world.Version >= 276)
                world.UnknownNoRef68Version = chunkReader.ReadExpectedTagValue(0x4361);

            if (world.Version >= 277)
                world.UnknownNoRef67Version = chunkReader.ReadExpectedTagValue(0x565a);

            if (world.Version >= 280)
                world.UnknownNoRef66Version = chunkReader.ReadExpectedTagValue(0x4153);

            if (world.Version >= 280)
                world.UnitOverrideAnimationActionVersion = chunkReader.ReadExpectedTagValue(0x4146);

            if (world.Version >= 287)
                world.UnknownNoRef65Version = chunkReader.ReadExpectedTagValue(0x5652);

            if (world.Version >= 287)
                world.UnknownNoRef64Version = chunkReader.ReadExpectedTagValue(0x4261);

            if (world.Version >= 290)
                world.UnknownNoRef63Version = chunkReader.ReadExpectedTagValue(0x4361);

            if (world.Version >= 291)
                world.UnknownNoRef62Version = chunkReader.ReadExpectedTagValue(0x4946);

            if (world.Version >= 291)
                world.UnknownNoRef61Version = chunkReader.ReadExpectedTagValue(0x4d61);

            if (world.Version >= 292)
                world.UnitDanceBonusActionVersion = chunkReader.ReadExpectedTagValue(0x4d61);

            if (world.Version >= 293)
                world.UnitLikeBonusModifyActionVersion = chunkReader.ReadExpectedTagValue(0x796d);

            if (world.Version >= 295)
                world.UnknownNoRef59Version = chunkReader.ReadExpectedTagValue(0x5361);

            if (world.Version >= 297)
                world.UnknownNoRef58Version = chunkReader.ReadExpectedTagValue(0x4946);

            if (world.Version >= 298)
                world.UnknownNoRef57Version = chunkReader.ReadExpectedTagValue(0x5652);

            if (world.Version >= 298)
                world.UnknownNoRef56Version = chunkReader.ReadExpectedTagValue(0x4946);

            if (world.Version >= 298)
                world.UnitActionVersion_2 = chunkReader.ReadExpectedTagValue(0x4341);

            if (world.Version >= 307)
                world.UnknownNoRef54Version = chunkReader.ReadExpectedTagValue(0x7964);


            world.ScenarioType = chunkReader.ReadString();
            world.MapCode = chunkReader.ReadString();

            if(world.Version >= 299)
            {
                world.Unk75C4 = chunkReader.ReadBoolean();
                world.Unk75C5 = chunkReader.ReadBoolean();
            }

            if(world.Version >= 305)
            {
                world.ScenarioTypeNum = chunkReader.ReadInt32();
            }

            // TODO: BProtoUnitTable
            chunkReader.ReadExpectedTagAndSkip(0x5450);

            // TODO: BStringToIDMap
            chunkReader.ReadExpectedTagAndSkip(0x4D54);
            chunkReader.ReadExpectedTagAndSkip(0x4D54);
            chunkReader.ReadExpectedTagAndSkip(0x4D54);

            // TODO: BCommandManager
            if(!unkA5)
                chunkReader.ReadExpectedTagAndSkip(0x324D);

            // TODO: BTerrain
            bool hasTerrain = chunkReader.ReadBoolean();
            if(hasTerrain)
                chunkReader.ReadExpectedTagAndSkip(0x3354);

            // TODO: ??? // TerrainMap ?
            if(world.Version > 227)
            {
                bool hasUnk = chunkReader.ReadBoolean();
                if(hasUnk)
                {
                    chunkReader.ReadExpectedTagAndSkip(0x4D54);
                }
            }

            // TODO: Cliffs
            var hasCliffs = chunkReader.ReadBoolean();
            if(hasCliffs)
            {
                if (world.Version <= 246)
                    throw new NotImplementedException("Compat cliffs are not implemeted");

                chunkReader.ReadExpectedTagAndSkip(0x4D43);
            }

            if(!unkA5)
            {
                world.Unk1BC = chunkReader.ReadInt32();
                world.Unk1C0 = chunkReader.ReadInt32();
            }
            else
            {
                world.UseTerrainHeightLimits = chunkReader.ReadBoolean();
                world.OceanReveal = chunkReader.ReadBoolean();
            }

            // ObstructionManager related
            world.Unk64 = chunkReader.ReadInt32();
            world.PlayerCount = chunkReader.ReadInt32();


            // TODO: Player
            for(int i = 0; i < world.PlayerCount; i++)
            {
                bool hasPlayerData = chunkReader.ReadBoolean();
                if(hasPlayerData)
                {
                    chunkReader.ReadExpectedTagAndSkip(0x5042);
                }
            }

            // TODO: Effect Manager
            if(!unkA5)
            {
                var unkEffectVersion = chunkReader.ReadExpectedTagValue(0x5654); // Some Version?
                chunkReader.ReadExpectedTagAndSkip(0x4D45);
            }

            // TODO: Tech Manager
            if(!unkA5)
            {
                var techManagerVersion = chunkReader.ReadExpectedTagValue(0x5654);
                chunkReader.ReadExpectedTagAndSkip(0x4D54);
            }

            // TODO: PEBoardTransport
            if (world.Version >= 231)
            {
                var numPEBoardTransport = chunkReader.ReadInt32();
                for(int i = 0; i < numPEBoardTransport; i++)
                {
                    var unkPEBoardTransportValue = chunkReader.ReadInt32();
                    chunkReader.ReadExpectedTagAndSkip(0x5442);
                }
            }

            // TODO: Reveal Manager
            if (world.Version >= 264)
            {
                // Read Unk Version 0x5252
                chunkReader.ReadExpectedTagAndSkip(0x5252);
            }

            // TODO: Units
            chunkReader.ReadExpectedTagAndSkip(0x315A);

            // TODO: Free Units
            if (!unkA5)
            {
                var numFreeUnits = chunkReader.ReadInt32();
                for(int i = 0; i < numFreeUnits; i++)
                {
                    var flags = chunkReader.ReadInt32();
                }
            }


            if(unkA5)
            {
                // this->bool_75A5 = ::AGame_0->mIsEditorMode != 1;
            }
            else
            {

            }


            return world;
        }

        public BangTriggerParam ReadNextTriggerParam()
        {
            BangTriggerParam param = new BangTriggerParam();
            param.Version = chunkReader.ReadInt32();
            param.Name = chunkReader.ReadASCIIString();
            param.DispName = chunkReader.ReadASCIIString();
            param.Unk20 = chunkReader.ReadInt32();

            var numParamsData = chunkReader.ReadInt32();
            if (param.Version > 1)
            {
                if (param.Version == 3) // Version 3
                {
                    for (int l = 0; l < numParamsData; l++)
                    {
                        if (param.Unk20 == 1)
                            param.ParamIntList.Add(chunkReader.ReadInt32());
                    }
                }
                else if (param.Version > 3)
                { // Version 4
                    for (int l = 0; l < numParamsData; l++)
                    {
                        if (param.Unk20 == 22)
                        {
                            param.ParamIntList.Add(chunkReader.ReadInt32());
                        }
                        param.ParamStringList.Add(chunkReader.ReadString());
                    }
                }
                else
                { // Version 2
                    for (int l = 0; l < numParamsData; l++)
                        param.ParamStringList.Add(chunkReader.ReadString());
                }
            }
            else
            { // Version 0-1
                for (int l = 0; l < numParamsData; l++)
                    param.ParamStringList.Add(chunkReader.ReadASCIIString());
            }
            return param;
        }

        public BangTriggerCommand ReadNextCommand()
        {
            BangTriggerCommand command = new BangTriggerCommand();

            command.Name = chunkReader.ReadASCIIString();
            command.Loaded = chunkReader.ReadBoolean();

            var numLoopParams = chunkReader.ReadInt32();
            for(int i = 0; i < numLoopParams; i++)
            {
                command.LoopParams.Add(chunkReader.ReadASCIIString());
            }

            return command;
        }

        public BangTriggerType ReadNextTriggerType()
        {
            // Bang Trigger Condition - START
            BangTriggerType triggerType = new BangTriggerType();
            triggerType.Version = chunkReader.ReadInt32();
            triggerType.Name = chunkReader.ReadASCIIString();
            if (triggerType.Version > 1)
            {
                triggerType.Unk0 = chunkReader.ReadASCIIString();
            }

            var numParams = chunkReader.ReadInt32();
            for (int k = 0; k < numParams; k++)
            {
                triggerType.Params.Add(ReadNextTriggerParam());
            }

            triggerType.Expression = chunkReader.ReadASCIIString();

            var numCommands = chunkReader.ReadInt32();
            for (int k = 0; k < numCommands; k++)
            {
                triggerType.Commands.Add(ReadNextCommand());
            }

            return triggerType;
            // Bang Trigger Condition - END
        }

        public void ReadBody(BangData dataToWrite)
        {
            // Note: AGame_func_1 (Age III)


            // Unknown params - START
            bool unkA5 = true;
            bool unkA7 = false;
            // Unknown params - END



            var fileVersion = dataToWrite.Header.FileVersion;

            if(fileVersion >= 41)
            {
                // maybe game generation 0 = AoM, 1 = AGE III, 2 = AOEO?
                // or it could be DLC --> AGE III, AGE III War Chiefs, AGE III Asians
                dataToWrite.GameType = chunkReader.ReadEnum<BangGameType>();
            }

            if (fileVersion > BangDataHeader.MaxFileVersion)
                throw new InvalidOperationException($"File version {fileVersion} is bigger than the max file version {BangDataHeader.MaxFileVersion}");

            if(fileVersion >= 31)
            {
                dataToWrite.SavedModeType = chunkReader.ReadEnum<BangModeType>();
                dataToWrite.ShouldInitWorld = chunkReader.ReadBoolean();
            }

            if(fileVersion >= 34 && dataToWrite.Header.UnkBool)
            {
                chunkReader.ReadExpectedTag(0x504D);
                // TODO: Skip rest
                return;
            } else if(fileVersion < 34) {
                // TODO: Read old data?
                // TODO: --> same as [fileVersion >= 34]
            }



            if(fileVersion >= 33)
            {
                if(fileVersion >= 34)
                {
                    if (unkA5)
                    {
                        dataToWrite.NumPlayers = chunkReader.ReadInt32();

                        // Fade settings (see setGameFadeIn)
                        dataToWrite.FadeInOut = chunkReader.ReadBoolean();
                        dataToWrite.FadeColor = BangColor.Read(chunkReader);
                        dataToWrite.FadeDuration = chunkReader.ReadInt32();
                        dataToWrite.FadeDelay = chunkReader.ReadInt32();
                    } else {
                        dataToWrite.FadeInOut = false;
                    }
                }

                // Home City Related
                bool unkBGameByte2744 = false;
                if(fileVersion < 43 || unkA5 != true)
                {
                    unkBGameByte2744 = true;
                } else {
                    // Home city related
                    chunkReader.ReadExpectedTag(0x4853);

                    int unkVal = chunkReader.ReadInt32();
                    int unkVal2 = chunkReader.ReadInt32();
                }

                // Campaign Related
                if(fileVersion >= 35)
                {
                    dataToWrite.CampaignIndex = chunkReader.ReadInt32();
                    int unkSubIndex = chunkReader.ReadInt32();
                }
            }

            if(!unkA7)
            {
                dataToWrite.PositionVersion = chunkReader.ReadInt32IfTagged(0x5650); // Unknown? Default 0?
                dataToWrite.ColorVersion = chunkReader.ReadInt32IfTagged(0x5656); // Unknown? Default 0?
                dataToWrite.CostVersion = chunkReader.ReadInt32IfTagged(0x5643); // Unknown? Default 1?
                dataToWrite.BitArrayVersion = chunkReader.ReadInt32IfTagged(0x4142); // Unknown? Default 0?
                dataToWrite.ConvexHullVersion = chunkReader.ReadInt32IfTagged(0x4843); // Unknown? Default 0?

                // Game specific load - START
                chunkReader.ReadExpectedTag(0x3352);
                var unkVal = chunkReader.ReadInt32();
                var arrayLen = chunkReader.ReadInt32();
                string format = chunkReader.ReadASCIIString(arrayLen);
                var readByte = chunkReader.ReadBoolean(); // TODO: Must be compared with unkA5
                // Game specific load - END

                // Selection manager - START
                chunkReader.ReadExpectedTag(0x4D53);
                dataToWrite.CurrentSelectionMode = chunkReader.ReadInt32();
                if(dataToWrite.CurrentSelectionMode != 0)
                {
                    var numTypedIds = chunkReader.ReadInt32();
                    for (int i = 0; i < numTypedIds; i++)
                    {
                        int valX = chunkReader.ReadInt32();
                        int valY = chunkReader.ReadInt32();
                        // throw new NotImplementedException("Missing typed ids impl for selection mode");
                    }
                } else {
                    throw new NotImplementedException("Missing impl for extended tags");
                }

                if(dataToWrite.CurrentSelectionMode == 0)
                {
                    throw new NotImplementedException("Missing impl");
                }
                
                if(dataToWrite.CurrentSelectionMode == 1)
                {
                    throw new NotImplementedException("Missing impl");
                }

                if(dataToWrite.CurrentSelectionMode == 2)
                {
                    throw new NotImplementedException("Missing impl");
                }

                if(dataToWrite.CurrentSelectionMode == 3)
                {
                    throw new InvalidOperationException("Invalid?");
                }

                if(dataToWrite.CurrentSelectionMode == 4)
                {
                    throw new NotImplementedException("Missing impl");
                }

                if(dataToWrite.CurrentSelectionMode == 5)
                {
                    var num = chunkReader.ReadInt32();
                    for (int i = 0; i < num; i++)
                    {
                        var numInner = chunkReader.ReadInt32();
                        for (int j = 0; j < numInner; j++)
                        {
                            var tmpVal = chunkReader.ReadInt32();
                        }
                    }
                }
                // Selection manager - END

                // Proto - START
                if(!unkA5)
                {
                    throw new NotImplementedException("Embedded proto data is not implemented");
                }
                // Proto - END

                // TechTree - START
                if(!unkA5)
                {
                    throw new NotImplementedException("Embedded tech tree data is not implemented");
                }
                // TechTree - END

                // Quest Manager - START
                if(fileVersion >= 44)
                {
                    chunkReader.ReadExpectedTag(0x4D51);
                    var questManagerUnkVal = chunkReader.ReadInt32();
                    if(unkA5 && questManagerUnkVal >= 2)
                    {
                        var numElems = chunkReader.ReadInt32();

                        for(int i = 0; i < numElems; i++)
                        {
                            BangQuestArea newArea = new BangQuestArea();
                            newArea.Name = chunkReader.ReadString();

                            chunkReader.ReadExpectedTag(0x5451);
                            int unkQuestSubVal = chunkReader.ReadInt32();

                            int unkQuestSubCount = chunkReader.ReadInt32();
                            for(int j = 0; j < unkQuestSubCount; j++)
                            {
                                BangPoint newPoint;
                                newPoint.X = chunkReader.ReadInt32();
                                newPoint.Y = chunkReader.ReadInt32();

                                newArea.Points.Add(newPoint);
                            }

                            dataToWrite.QuestAreas.Add(newArea);
                        }
                    }
                }
                // Quest Manager - END


                // Trigger Manager - START
                chunkReader.ReadExpectedTag(0x5254);
                dataToWrite.TriggerManagerVersion = chunkReader.ReadInt32();

                var unkTriggerManagerDword0 = chunkReader.ReadInt32();
                if(dataToWrite.TriggerManagerVersion > 4)
                {
                    dataToWrite.TriggerNewID = chunkReader.ReadInt32();

                    if(dataToWrite.TriggerManagerVersion > 6)
                    {
                        chunkReader.ReadInt32(); // Unknown DWORD8?
                    }

                    int numOfTriggers = chunkReader.ReadInt32();
                    for(int i = 0; i < numOfTriggers; i++)
                    {
                        // Trigger - START
                        BangTrigger trigger = new BangTrigger();

                        trigger.Version = chunkReader.ReadInt32();
                        if(trigger.Version != 0)
                        {
                            
                            trigger.ID = chunkReader.ReadInt32();
                            if(trigger.Version > 1)
                            {
                                trigger.GroupID = chunkReader.ReadInt32();
                            }
                            if(trigger.Version > 2)
                            {
                                trigger.Priority = chunkReader.ReadInt32();
                            }

                            trigger.Name = chunkReader.ReadASCIIString();
                            if(trigger.Version <= 2)
                            {
                                var name2 = chunkReader.ReadASCIIString();
                                var name3 = chunkReader.ReadASCIIString();
                            }

                            trigger.Unk2C = chunkReader.ReadInt32();
                            trigger.Loop = chunkReader.ReadBoolean();
                            trigger.IsActive = chunkReader.ReadBoolean();
                            trigger.RunImmediatly = chunkReader.ReadBoolean();
                            
                            if(trigger.Version >= 6)
                            {
                                trigger.Not = chunkReader.ReadBoolean();
                                trigger.Or = chunkReader.ReadBoolean();
                            }

                            var numConditions = chunkReader.ReadInt32();
                            for(int j = 0; j < numConditions; j++)
                            {
                                trigger.Conditions.Add(ReadNextTriggerType());
                            }

                            var numEffects = chunkReader.ReadInt32();
                            for (int j = 0; j < numEffects; j++)
                            {
                                trigger.Effects.Add(ReadNextTriggerType());
                            }
                        }

                        dataToWrite.Triggers.Add(trigger);
                        // Trigger - END
                    }

                    if(dataToWrite.TriggerManagerVersion > 5)
                    {
                        // Groups
                        int numGroups = chunkReader.ReadInt32();
                        for(int i = 0; i < numGroups; i++)
                        {
                            BangTriggerGroup newGroup = new BangTriggerGroup();
                            
                            int unkTrigGroupVal = chunkReader.ReadInt32();
                            if(unkTrigGroupVal != 0)
                            {
                                int unkTrigGroupDWord0 = chunkReader.ReadInt32(); // ID / Index ?

                                newGroup.Name = chunkReader.ReadASCIIString();
                                int numTriggerIDs = chunkReader.ReadInt32();
                                for(int j = 0; j < numTriggerIDs; j++)
                                {
                                    newGroup.TriggerIDs.Add(chunkReader.ReadInt32());
                                }
                            }

                            dataToWrite.TriggerGroups.Add(newGroup);
                        }
                    }

                }
                // Trigger Manager - END

                // World - START
                dataToWrite.World = ReadWorld(unkA5);
                // World - END
            }




        }

        public BangData ReadAll()
        {
            BangData data = new BangData();

            data.Header = ReadHeader();

            ReadBody(data);

            return data;
        }
    }
}
