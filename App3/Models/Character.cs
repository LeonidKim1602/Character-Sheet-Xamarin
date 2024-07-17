using SQLite;


namespace App3.Models
{
    public class Character
    {


        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public int? Level { get; set; }
        public string Race { get; set; }
        public string Background { get; set; }
        public string Alignment { get; set; }
        public int? Experience { get; set; }
        public int? Armor { get; set; }
        public int? Initiative { get; set; }
        public int? Speed { get; set; }
        public int? MaxHP { get; set; }
        public int? HP { get; set; }
        public int? TempHP { get; set; }
        public int? DSSuccess { get; set; }
        public int? DSFailure { get; set; }
        public int? Acrobatics { get; set; }
        public int? AnimalHandling { get; set; }
        public int? Arcana { get; set; }
        public int? Athletics { get; set; }
        public int? Deception { get; set; }
        public int? History { get; set; }
        public int? Insight { get; set; }
        public int? Intimidation { get; set; }
        public int? Investigation { get; set; }
        public int? Medicine { get; set; }
        public int? Nature { get; set; }
        public int? Perception { get; set; }
        public int? Performance { get; set; }
        public int? Persuasion { get; set; }
        public int? Religion { get; set; }
        public int? SleightOfHand { get; set; }
        public int? Stealth { get; set; }
        public int? Survival { get; set; }
        public int? StrengthST { get; set; }
        public int? DexterityST { get; set; }
        public int? ConstitutionST { get; set; }
        public int? IntelligenceST { get; set; }
        public int? WisdomST { get; set; }
        public int? CharismaST { get; set; }
        public int? Strength { get; set; }
        public int? Dexterity { get; set; }
        public int? Constitution { get; set; }
        public int? Intelligence { get; set; }
        public int? Wisdom { get; set; }
        public int? Charisma { get; set; }
        public int? Inspiration { get; set; }
        public int? ProfficiencyBonus { get; set; }

    }
}
