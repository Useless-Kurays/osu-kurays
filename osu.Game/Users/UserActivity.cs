// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Game.Beatmaps;
using osu.Game.Graphics;
using osu.Game.Online.Multiplayer;
using osu.Game.Rulesets;
using osuTK.Graphics;

namespace osu.Game.Users
{
    public abstract class UserActivity
    {
        public abstract string Status { get; }
        public virtual Color4 GetAppropriateColour(OsuColour colours) => colours.GreenDarker;

        public class Modding : UserActivity
        {
            public override string Status => "Делаем мапу";
            public override Color4 GetAppropriateColour(OsuColour colours) => colours.PurpleDark;
        }

        public class ChoosingBeatmap : UserActivity
        {
            public override string Status => "Выбираем мапу";
        }

        public class MultiplayerGame : UserActivity
        {
            public override string Status => "Играем с челиками";
        }

        public class Editing : UserActivity
        {
            public BeatmapInfo Beatmap { get; }

            public Editing(BeatmapInfo info)
            {
                Beatmap = info;
            }

            public override string Status => @"Редактируем мапу";
        }

        public class SoloGame : UserActivity
        {
            public BeatmapInfo Beatmap { get; }

            public RulesetInfo Ruleset { get; }

            public SoloGame(BeatmapInfo info, RulesetInfo ruleset)
            {
                Beatmap = info;
                Ruleset = ruleset;
            }

            public override string Status => Ruleset.CreateInstance().PlayingVerb;
        }

        public class Spectating : UserActivity
        {
            public override string Status => @"Наблюдаем за челиком";
        }

        public class SearchingForLobby : UserActivity
        {
            public override string Status => @"Ищем лобби";
        }

        public class InLobby : UserActivity
        {
            public override string Status => @"Сидим в лобби";

            public readonly Room Room;

            public InLobby(Room room)
            {
                Room = room;
            }
        }
    }
}
