using System;
using System.Collections.Generic;
using System.Text;

namespace BANGReader.Core.Data
{
    public class BangData
    {
        public BangDataHeader Header { get; set; } = null;

        // General
        public BangGameRequirements GameType { get; set; } = BangGameRequirements.RequiresBaseGame;
        public BangModeType SavedModeType { get; set; } = BangModeType.Invalid;
        public bool ShouldInitWorld { get; set; } = true;

        public int NumPlayers { get; set; } = 0;

        // Fade Settings
        public bool FadeInOut { get; set; } = false;
        public BangColor FadeColor { get; set; }
        public int FadeDuration { get; set; } = 0;
        public int FadeDelay { get; set; } = 0;

        // HomeCityManager
        public BangHomeCityManager HomeCityManager { get; set; } = null;

        // Campaign Settings
        public int CampaignIndex { get; set; } = -1;

        // Version Information
        public int PositionVersion { get; set; } = 0;
        public int ColorVersion { get; set; } = 0;
        public int CostVersion { get; set; } = 0;
        public int BitArrayVersion { get; set; } = 0;
        public int ConvexHullVersion { get; set; } = 0;

        // Selection Mode
        public int CurrentSelectionMode { get; set; } = 0; // TODO: Make Enum

        // Quest Areas
        public List<BangQuestArea> QuestAreas { get; set; } = new List<BangQuestArea>();

        // Triggers
        public int TriggerManagerVersion { get; set; } = 0;
        public int TriggerNewID { get; set; } = 0;
        public List<BangTrigger> Triggers { get; set; } = new List<BangTrigger>();

        // TODO: Triggers itself
        public List<BangTriggerGroup> TriggerGroups { get; set; } = new List<BangTriggerGroup>();

        // World
        public BangWorld World { get; set; } = null;
    }
}
