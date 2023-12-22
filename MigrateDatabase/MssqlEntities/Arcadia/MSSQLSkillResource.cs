using System.ComponentModel.DataAnnotations;

namespace MigrateDatabase.MssqlEntities.Arcadia;

public class MSSQLSkillResource
{
	[Key] public int id { get; set; }
	public int text_id { get; set; }
	public int desc_id { get; set; }
	public int tooltip_id { get; set; }
	public byte is_valid { get; set; }
	public string elemental { get; set; }
	public string is_passive { get; set; }
	public string is_physical_act { get; set; }
	public string is_harmful { get; set; }
	public string is_need_target { get; set; }
	public string is_corpse { get; set; }
	public string is_toggle { get; set; }
	public int toggle_group { get; set; }
	public string casting_type { get; set; }
	public string casting_level { get; set; }
	public int cast_range { get; set; }
	public int valid_range { get; set; }
	public int cost_hp { get; set; }
	public int cost_hp_per_skl { get; set; }
	public int cost_mp { get; set; }
	public int cost_mp_per_skl { get; set; }
	public int cost_mp_per_enhance { get; set; }
	public decimal cost_hp_per { get; set; }
	public decimal cost_hp_per_skl_per { get; set; }
	public decimal cost_mp_per { get; set; }
	public decimal cost_mp_per_skl_per { get; set; }
	public int cost_havoc { get; set; }
	public int cost_havoc_per_skl { get; set; }
	public decimal cost_energy { get; set; }
	public decimal cost_energy_per_skl { get; set; }
	public int cost_exp { get; set; }
	public int cost_exp_per_enhance { get; set; }
	public int cost_jp { get; set; }
	public int cost_jp_per_enhance { get; set; }
	public int cost_item { get; set; }
	public int cost_item_count { get; set; }
	public int cost_item_count_per_skl { get; set; }
	public int need_level { get; set; }
	public int need_hp { get; set; }
	public int need_mp { get; set; }
	public int need_havoc { get; set; }
	public int need_havoc_burst { get; set; }
	public int need_state_id { get; set; }
	public byte need_state_level { get; set; }
	public byte need_state_exhaust { get; set; }
	public string vf_one_hand_sword { get; set; }
	public string vf_two_hand_sword { get; set; }
	public string vf_double_sword { get; set; }
	public string vf_dagger { get; set; }
	public string vf_double_dagger { get; set; }
	public string vf_spear { get; set; }
	public string vf_axe { get; set; }
	public string vf_one_hand_axe { get; set; }
	public string vf_double_axe { get; set; }
	public string vf_one_hand_mace { get; set; }
	public string vf_two_hand_mace { get; set; }
	public string vf_lightbow { get; set; }
	public string vf_heavybow { get; set; }
	public string vf_crossbow { get; set; }
	public string vf_one_hand_staff { get; set; }
	public string vf_two_hand_staff { get; set; }
	public string vf_shield_only { get; set; }
	public string vf_is_not_need_weapon { get; set; }
	public decimal delay_cast { get; set; }
	public decimal delay_cast_per_skl { get; set; }
	public decimal delay_cast_mode_per_enhance { get; set; }
	public decimal delay_common { get; set; }
	public decimal delay_cooltime { get; set; }
	public decimal delay_cooltime_per_skl { get; set; }
	public decimal delay_cooltime_mode_per_enhance { get; set; }
	public int cool_time_group_id { get; set; }
	public string uf_self { get; set; }
	public string uf_party { get; set; }
	public string uf_guild { get; set; }
	public string uf_neutral { get; set; }
	public string uf_purple { get; set; }
	public string uf_enemy { get; set; }
	public string tf_avatar { get; set; }
	public string tf_summon { get; set; }
	public string tf_monster { get; set; }
	public string skill_lvup_limit { get; set; }
	public short target { get; set; }
	public short effect_type { get; set; }
	public int skill_enchant_link_id { get; set; }
	public int state_id { get; set; }
	public int state_level_base { get; set; }
	public decimal state_level_per_skl { get; set; }
	public decimal state_level_per_enhance { get; set; }
	public decimal state_second { get; set; }
	public decimal state_second_per_level { get; set; }
	public decimal state_second_per_enhance { get; set; }
	public int probability_on_hit { get; set; }
	public int probability_inc_by_slv { get; set; }
	public short hit_bonus { get; set; }
	public short hit_bonus_per_enhance { get; set; }
	public short percentage { get; set; }
	public decimal hate_mod { get; set; }
	public short hate_basic { get; set; }
	public decimal hate_per_skl { get; set; }
	public decimal hate_per_enhance { get; set; }
	public int critical_bonus { get; set; }
	public int critical_bonus_per_skl { get; set; }
	public decimal var1 { get; set; }
	public decimal var2 { get; set; }
	public decimal var3 { get; set; }
	public decimal var4 { get; set; }
	public decimal var5 { get; set; }
	public decimal var6 { get; set; }
	public decimal var7 { get; set; }
	public decimal var8 { get; set; }
	public decimal var9 { get; set; }
	public decimal var10 { get; set; }
	public decimal var11 { get; set; }
	public decimal var12 { get; set; }
	public decimal var13 { get; set; }
	public decimal var14 { get; set; }
	public decimal var15 { get; set; }
	public decimal var16 { get; set; }
	public decimal var17 { get; set; }
	public decimal var18 { get; set; }
	public decimal var19 { get; set; }
	public decimal var20 { get; set; }
	public int icon_id { get; set; }
	public string icon_file_name { get; set; }
	public byte is_projectile { get; set; }
	public decimal projectile_speed { get; set; }
	public decimal projectile_acceleration { get; set; }
}