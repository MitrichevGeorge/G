// Warning: Some assembly references could not be resolved automatically. This might lead to incorrect decompilation of some parts,
// for ex. property getter/setter access. To get optimal decompilation results, please manually add the missing references to the list of loaded assemblies.
// VehiclePhysics, Version=9.5.9021.31941, Culture=neutral, PublicKeyToken=null
// VehiclePhysics.VPStandardInput
using System;
using System.Runtime.CompilerServices;
using EdyCommonTools;
using UnityEngine;
using VehiclePhysics;

[AddComponentMenu("Vehicle Physics/Input/Standard Input", 0)]
public class VPStandardInput : VehicleBehaviour
{
	public enum ThrottleAndBrakeMode
	{
		ThrottleAndBrake,
		AutoForwardAndReverse
	}

	public enum IgnitionKey
	{
		Off,
		AccOn,
		Start
	}

	public ThrottleAndBrakeMode throttleAndBrakeMode = ThrottleAndBrakeMode.AutoForwardAndReverse;

	public bool brakeOnThrottleBackwards = true;

	public bool applyClutchOnHandbrake = true;

	public bool unlockDrivelineOnHandbrake = true;

	[Space(10f)]
	public bool progressiveSteerMode;

	[Range(0.01f, 1f)]
	public float movementRate = 0.25f;

	[Range(0f, 1f)]
	public float autoCenterRate = 0.01f;

	[Space(10f)]
	public KeyCode ignitionKey = (KeyCode)107;

	public string steerAxis = global::_003CModule_003E._206A_202E_202A_202E_206C_202E_200C_202A_206A_200D_200C_206F_200D_200C_206E_206A_202D_200E_206B_206A_200C_202E_202D_206D_200B_200E_200F_206D_206C_202A_206F_206E_206B_202D_202C_202D_206E_200B_200C_202B_202E<string>(316888312);

	public string throttleAndBrakeAxis = global::_003CModule_003E._206B_202E_200D_200F_206B_200B_200E_206D_206C_206E_200C_206B_206B_200E_200B_206A_206C_202C_200B_200D_206C_206B_206D_206E_206A_200E_200E_200E_206B_202A_202A_200F_200B_202E_200F_206C_200C_206C_200D_202C_202E<string>(975058905);

	public string handbrakeAxis = global::_003CModule_003E._200C_206C_202C_200F_206C_200B_206A_202D_206F_206D_200E_202B_202D_200C_202C_200F_202E_200D_202D_200B_200B_206C_206C_206D_202A_202A_200E_202D_206E_200C_200C_202D_206D_202C_200D_202E_202A_206E_202D_202A_202E<string>(-1712287250);

	public string clutchAxis = global::_003CModule_003E._200C_206C_200F_206E_206C_200B_202C_202B_200F_200D_200C_200B_200E_202C_200E_206C_206E_200E_202D_202E_200E_200B_202D_202D_202C_202B_206C_206F_200F_206D_206B_206F_202D_200E_206E_202A_202E_206F_206C_202E_202E<string>(-1597721215);

	public string gearShiftButton = global::_003CModule_003E._206A_202E_202A_202E_206C_202E_200C_202A_206A_200D_200C_206F_200D_200C_206E_206A_202D_200E_206B_206A_200C_202E_202D_206D_200B_200E_200F_206D_206C_202A_206F_206E_206B_202D_202C_202D_206E_200B_200C_202B_202E<string>(-1975647108);

	public string gearModeSelectButton = global::_003CModule_003E._200C_206C_200F_206E_206C_200B_202C_202B_200F_200D_200C_200B_200E_202C_200E_206C_206E_200E_202D_202E_200E_200B_202D_202D_202C_202B_206C_206F_200F_206D_206B_206F_202D_200E_206E_202A_202E_206F_206C_202E_202E<string>(2020847503);

	public bool keyboardNumbersSelectGears = true;

	public KeyCode neutralGear = (KeyCode)110;

	public KeyCode reverseGear = (KeyCode)114;

	[Space(10f)]
	public bool disableSteerInput;

	public bool disableThrottleInput;

	public bool disableBrakeInput;

	public bool disableHandbrakeInput;

	public bool disableClutchInput;

	public bool disableGearShiftInputs;

	[Space(10f)]
	[Range(0f, 1f)]
	public float externalThrottle;

	public bool reverse;

	[Range(0f, 1f)]
	public float externalBrake;

	[Range(0f, 1f)]
	public float externalHandbrake;

	[Range(-1f, 1f)]
	public float externalSteer;

	[Range(0f, 1f)]
	public float externalClutch;

	public IgnitionKey externalIgnition = IgnitionKey.AccOn;

	public bool lockBrakesOnEnable;

	[NonSerialized]
	public float minStoppedSpeed = 0.1f;

	[NonSerialized]
	public float maxStoppedSpeed = 1f;

	private bool _202B_206C_200E_202C_202E_200B_206F_200C_202C_206E_202A_206D_206C_202A_202C_206A_202A_206C_206A_206E_206C_200F_206E_200C_200F_200B_202C_206B_200D_200D_206E_202D_202E_200F_206A_202C_200C_206F_202B_200E_202E;

	private bool _200E_202C_206C_206E_202D_200F_202A_202A_206F_202A_202D_200F_206C_202E_200B_200D_206B_202B_200E_206B_200C_200E_206E_206A_200D_200D_202D_202B_202C_200D_200F_200C_202B_206B_206E_200F_202D_200B_202A_206B_202E;

	private bool _202C_206C_200F_206B_206C_202E_206F_200E_202C_200B_200D_206A_202B_206E_206C_202A_202C_206F_202A_202A_200F_206D_206C_200E_206A_206F_202E_202D_206E_202B_200D_202A_200B_206D_202B_202C_206D_206D_202B_202A_202E;

	private IgnitionKey _202C_206D_206A_202A_200E_202C_200E_206D_200E_206C_206B_202E_202D_206D_200F_206F_206D_206B_206F_206C_206C_200D_206A_200F_206C_206F_200F_200B_200E_200E_206B_206E_202C_200B_206E_202D_200B_202D_202B_202E_202E;

	private int _200B_200E_206B_200D_200D_202B_200E_200F_206B_206F_202B_200E_202E_206C_206C_202B_200F_202C_200B_200D_202B_200C_206D_202C_206C_200E_200D_200C_202E_206E_206B_202B_206E_200C_206C_200D_202B_200E_202E_206D_202E;

	private float _202B_200B_206F_206C_200E_206C_206E_206E_200B_202E_200D_202A_206D_206D_202A_206D_202D_202A_206E_202D_202E_200F_200F_206D_206E_202E_202B_202A_200C_200F_200C_202D_206A_206B_202E_206A_206F_200E_202C_206A_202E;

	public override void OnEnableVehicle()
	{
		_202B_206C_200E_202C_202E_200B_206F_200C_202C_206E_202A_206D_206C_202A_202C_206A_202A_206C_206A_206E_206C_200F_206E_200C_200F_200B_202C_206B_200D_200D_206E_202D_202E_200F_206A_202C_200C_206F_202B_200E_202E = lockBrakesOnEnable;
		while (true)
		{
			int num = 1616308331;
			while (true)
			{
				int num2 = num;
				uint num3;
				switch ((num3 = (uint)(-1922957412 - (~(-num2) - -36253791))) % 7)
				{
				case 0u:
					break;
				default:
					return;
				case 6u:
					_200E_202C_206C_206E_202D_200F_202A_202A_206F_202A_202D_200F_206C_202E_200B_200D_206B_202B_200E_206B_200C_200E_206E_206A_200D_200D_202D_202B_202C_200D_200F_200C_202B_206B_206E_200F_202D_200B_202A_206B_202E = false;
					num = ((int)num3 * -288480085) ^ 0x754CC2E7;
					continue;
				case 5u:
					_202C_206D_206A_202A_200E_202C_200E_206D_200E_206C_206B_202E_202D_206D_200F_206F_206D_206B_206F_206C_206C_200D_206A_200F_206C_206F_200F_200B_200E_200E_206B_206E_202C_200B_206E_202D_200B_202D_202B_202E_202E = (IgnitionKey)(-1);
					num = ((int)num3 * -1590507984) ^ -770885462;
					continue;
				case 3u:
					_202B_200B_206F_206C_200E_206C_206E_206E_200B_202E_200D_202A_206D_206D_202A_206D_202D_202A_206E_202D_202E_200F_200F_206D_206E_202E_202B_202A_200C_200F_200C_202D_206A_206B_202E_206A_206F_200E_202C_206A_202E = 0f;
					num = (int)((num3 * 1265023102) ^ 0x14E314A4);
					continue;
				case 1u:
					_200B_200E_206B_200D_200D_202B_200E_200F_206B_206F_202B_200E_202E_206C_206C_202B_200F_202C_200B_200D_202B_200C_206D_202C_206C_200E_200D_200C_202E_206E_206B_202B_206E_200C_206C_200D_202B_200E_202E_206D_202E = ((base.vehicle.speed > maxStoppedSpeed) ? 1 : ((base.vehicle.speed < 0f - maxStoppedSpeed) ? (-1) : 0));
					num = -2127539190;
					continue;
				case 2u:
					_202C_206C_200F_206B_206C_202E_206F_200E_202C_200B_200D_206A_202B_206E_206C_202A_202C_206F_202A_202A_200F_206D_206C_200E_206A_206F_202E_202D_206E_202B_200D_202A_200B_206D_202B_202C_206D_206D_202B_202A_202E = false;
					num = (int)(num3 * 1272031288) ^ -1727956127;
					continue;
				case 4u:
					return;
				}
				break;
			}
		}
	}

	public override void OnDisableVehicle()
	{
		int[] array = base.vehicle.data.Get(0);
		if (!disableThrottleInput)
		{
			goto IL_001d;
		}
		goto IL_00cf;
		IL_001d:
		int num = 505103967;
		goto IL_0022;
		IL_0022:
		while (true)
		{
			int num2 = num;
			uint num3;
			switch ((num3 = (uint)(((-1253982388 ^ 0xF40E76E) - -num2 - 2061203130) * -1238756005)) % 9)
			{
			case 8u:
				break;
			default:
				return;
			case 1u:
				goto IL_0077;
			case 6u:
				array[4] = 0;
				num = ((int)num3 * -1158655022) ^ -248100281;
				continue;
			case 0u:
				array[2] = 0;
				num = ((int)num3 * -429258091) ^ 0x53BFC53C;
				continue;
			case 2u:
				array[9] = 0;
				num = (int)((num3 * 516049945) ^ 0x5B408F69);
				continue;
			case 7u:
				goto IL_00cf;
			case 3u:
				goto IL_00eb;
			case 5u:
				array[1] = 0;
				num = (int)((num3 * 803328850) ^ 0x6DCD9EA8);
				continue;
			case 4u:
				return;
			}
			break;
			IL_00eb:
			int num4;
			if (!disableClutchInput)
			{
				num = -1715088080;
				num4 = num;
			}
			else
			{
				num = 1135547607;
				num4 = num;
			}
			continue;
			IL_0077:
			int num5;
			if (array[9] == 1)
			{
				num = 1684918065;
				num5 = num;
			}
			else
			{
				num = -994768958;
				num5 = num;
			}
		}
		goto IL_001d;
		IL_00cf:
		int num6;
		if (!disableBrakeInput)
		{
			num = 1884428704;
			num6 = num;
		}
		else
		{
			num = 1096010116;
			num6 = num;
		}
		goto IL_0022;
	}

	public override void FixedUpdateVehicle()
	{
		if (!_202D_200D_200C_206B_202A_200D_206D_206A_206C_200C_206B_206E_202B_206A_202C_202B_200F_206E_202A_200D_206F_200E_202B_200E_206C_202E_206A_202B_200B_206A_206E_206D_206B_206F_200D_200D_206E_202D_206F_206C_202E((KeyCode)306))
		{
			goto IL_000f;
		}
		int num = 1;
		goto IL_087f;
		IL_0872:
		num = (_202D_200D_200C_206B_202A_200D_206D_206A_206C_200C_206B_206E_202B_206A_202C_202B_200F_206E_202A_200D_206F_200E_202B_200E_206C_202E_206A_202B_200B_206A_206E_206D_206B_206F_200D_200D_206E_202D_206F_206C_202E((KeyCode)305) ? 1 : 0);
		goto IL_087f;
		IL_000f:
		int num2 = 789361090;
		goto IL_0014;
		IL_0014:
		int[] array = default(int[]);
		float num33 = default(float);
		float num7 = default(float);
		float num22 = default(float);
		int[] array3 = default(int[]);
		int num30 = default(int);
		int[] array2 = default(int[]);
		float num11 = default(float);
		float num10 = default(float);
		bool flag = default(bool);
		ThrottleAndBrakeMode throttleAndBrakeMode = default(ThrottleAndBrakeMode);
		float speed = default(float);
		while (true)
		{
			int num3 = num2;
			uint num4;
			float num25;
			switch ((num4 = (uint)(~num3 * 2143001487)) % 100)
			{
			case 10u:
				break;
			default:
				return;
			case 2u:
			{
				int num69;
				int num70;
				if (array[3] == 0)
				{
					num69 = 306786517;
					num70 = num69;
				}
				else
				{
					num69 = -538695962;
					num70 = num69;
				}
				num2 = num69 ^ ((int)num4 * -289373396);
				continue;
			}
			case 55u:
				num33 = num7;
				num2 = (int)((num4 * 675485546) ^ 0x6D894D1C);
				continue;
			case 20u:
			{
				int num26;
				int num27;
				if (_200B_200E_206B_200D_200D_202B_200E_200F_206B_206F_202B_200E_202E_206C_206C_202B_200F_202C_200B_200D_202B_200C_206D_202C_206C_200E_200D_200C_202E_206E_206B_202B_206E_200C_206C_200D_202B_200E_202E_206D_202E <= 0)
				{
					num26 = 2120865447;
					num27 = num26;
				}
				else
				{
					num26 = -663578579;
					num27 = num26;
				}
				num2 = num26 ^ (int)(num4 * 1386153743);
				continue;
			}
			case 32u:
				goto IL_021e;
			case 91u:
				goto IL_023a;
			case 24u:
			{
				int num52;
				int num53;
				if (Mathf.Abs(num22) < 0.01f)
				{
					num52 = 1825340057;
					num53 = num52;
				}
				else
				{
					num52 = 294436617;
					num53 = num52;
				}
				num2 = num52 ^ (int)(num4 * 1796120823);
				continue;
			}
			case 14u:
				array3[5] = 1;
				num2 = ((int)num4 * -486674470) ^ 0x668E0414;
				continue;
			case 48u:
				num2 = (int)((num4 * 749990706) ^ 0x6C73285F);
				continue;
			case 70u:
				goto IL_02ab;
			case 51u:
				_200E_202C_206C_206E_202D_200F_202A_202A_206F_202A_202D_200F_206C_202E_200B_200D_206B_202B_200E_206B_200C_200E_206E_206A_200D_200D_202D_202B_202C_200D_200F_200C_202B_206B_206E_200F_202D_200B_202A_206B_202E = false;
				num2 = -442985894;
				continue;
			case 74u:
			{
				int num58;
				int num59;
				if (progressiveSteerMode)
				{
					num58 = -196292696;
					num59 = num58;
				}
				else
				{
					num58 = 1314159339;
					num59 = num58;
				}
				num2 = num58 ^ ((int)num4 * -615630739);
				continue;
			}
			case 54u:
				goto IL_0309;
			case 41u:
				_202B_200B_206F_206C_200E_206C_206E_206E_200B_202E_200D_202A_206D_206D_202A_206D_202D_202A_206E_202D_202E_200F_200F_206D_206E_202E_202B_202A_200C_200F_200C_202D_206A_206B_202E_206A_206F_200E_202C_206A_202E = Mathf.MoveTowards(_202B_200B_206F_206C_200E_206C_206E_206E_200B_202E_200D_202A_206D_206D_202A_206D_202D_202A_206E_202D_202E_200F_200F_206D_206E_202E_202B_202A_200C_200F_200C_202D_206A_206B_202E_206A_206F_200E_202C_206A_202E, Mathf.Sign(num22), movementRate * _202C_202A_202D_202D_200B_206A_206B_200C_200D_206F_200E_206D_202A_200B_202A_202B_206A_206F_202A_206F_206C_200E_206F_202A_206E_206F_202C_206C_206A_206C_200B_206F_200F_202A_202B_206B_206A_206E_202C_202A_202E());
				num2 = (int)(num4 * 286599742) ^ -1881978327;
				continue;
			case 28u:
			{
				int num38;
				int num39;
				if (num30 >= 0)
				{
					num38 = -957164307;
					num39 = num38;
				}
				else
				{
					num38 = -810953360;
					num39 = num38;
				}
				num2 = num38 ^ ((int)num4 * -1218245104);
				continue;
			}
			case 37u:
				array2[3] = 0;
				num2 = (int)((num4 * 1055228643) ^ 0xB6828C0);
				continue;
			case 44u:
				goto IL_0399;
			case 93u:
				array3[6] = 2;
				num2 = (int)((num4 * 1753407385) ^ 0x3168DAFE);
				continue;
			case 47u:
				goto IL_03cc;
			case 79u:
				num22 = Mathf.Clamp(GetAxisRaw(steerAxis) + externalSteer, -1f, 1f);
				num2 = ((int)num4 * -344786943) ^ 0x3AB1F1C;
				continue;
			case 49u:
				array3[6] = 4;
				num2 = (int)((num4 * 752674385) ^ 0x63184984);
				continue;
			case 78u:
			{
				int num16;
				int num17;
				if (_200B_200E_206B_200D_200D_202B_200E_200F_206B_206F_202B_200E_202E_206C_206C_202B_200F_202C_200B_200D_202B_200C_206D_202C_206C_200E_200D_200C_202E_206E_206B_202B_206E_200C_206C_200D_202B_200E_202E_206D_202E >= 0)
				{
					num16 = -1101689079;
					num17 = num16;
				}
				else
				{
					num16 = -608358435;
					num17 = num16;
				}
				num2 = num16 ^ (int)(num4 * 1117521562);
				continue;
			}
			case 13u:
				num33 = 0f;
				num2 = ((int)num4 * -1855077326) ^ -1608514569;
				continue;
			case 34u:
			{
				int num56;
				int num57;
				if (num11 > num10)
				{
					num56 = -545055286;
					num57 = num56;
				}
				else
				{
					num56 = -1292171933;
					num57 = num56;
				}
				num2 = num56 ^ ((int)num4 * -410873366);
				continue;
			}
			case 25u:
			{
				int num50;
				int num51;
				if (_200B_200E_206B_200D_200D_202B_200E_200F_206B_206F_202B_200E_202E_206C_206C_202B_200F_202C_200B_200D_202B_200C_206D_202C_206C_200E_200D_200C_202E_206E_206B_202B_206E_200C_206C_200D_202B_200E_202E_206D_202E >= 0)
				{
					num50 = 112744423;
					num51 = num50;
				}
				else
				{
					num50 = -870006360;
					num51 = num50;
				}
				num2 = num50 ^ ((int)num4 * -347225510);
				continue;
			}
			case 69u:
				goto IL_04c1;
			case 73u:
			{
				array3[6] = 4;
				int num31;
				int num32;
				if (num30 < 0)
				{
					num31 = -1196734456;
					num32 = num31;
				}
				else
				{
					num31 = -977800554;
					num32 = num31;
				}
				num2 = num31 ^ (int)(num4 * 1493158984);
				continue;
			}
			case 75u:
				array2[3] = 0;
				_202C_206C_200F_206B_206C_202E_206F_200E_202C_200B_200D_206A_202B_206E_206C_202A_202C_206F_202A_202A_200F_206D_206C_200E_206A_206F_202E_202D_206E_202B_200D_202A_200B_206D_202B_202C_206D_206D_202B_202A_202E = false;
				num2 = ((int)num4 * -146835231) ^ 0x2179D898;
				continue;
			case 23u:
				goto IL_0521;
			case 53u:
			{
				int num14;
				int num15;
				if (num10 <= 0.1f)
				{
					num14 = -633012541;
					num15 = num14;
				}
				else
				{
					num14 = -983079546;
					num15 = num14;
				}
				num2 = num14 ^ ((int)num4 * -945756010);
				continue;
			}
			case 68u:
			{
				int num74;
				int num75;
				if (_200B_200E_206B_200D_200D_202B_200E_200F_206B_206F_202B_200E_202E_206C_206C_202B_200F_202C_200B_200D_202B_200C_206D_202C_206C_200E_200D_200C_202E_206E_206B_202B_206E_200C_206C_200D_202B_200E_202E_206D_202E != 1)
				{
					num74 = 161449454;
					num75 = num74;
				}
				else
				{
					num74 = -1056444122;
					num75 = num74;
				}
				num2 = num74 ^ ((int)num4 * -1877705395);
				continue;
			}
			case 15u:
				num11 = Mathf.Max(num10, num11);
				num10 = 0f;
				num2 = ((int)num4 * -290162763) ^ 0x186A6BAC;
				continue;
			case 98u:
			{
				float num71 = num10;
				num10 = num11;
				num11 = num71;
				num2 = -1627486771;
				continue;
			}
			case 90u:
			{
				float axis = GetAxis(throttleAndBrakeAxis);
				_ = (float)array[0] / 1000f;
				num10 = Mathf.Clamp(Mathf.Clamp01(axis) + externalThrottle * (float)((!reverse) ? 1 : (-1)), -1f, 1f);
				num11 = Mathf.Clamp01(0f - axis + externalBrake);
				num2 = 1313801093;
				continue;
			}
			case 58u:
				num30 = array[12];
				num2 = 424025579;
				continue;
			case 65u:
				_202B_200B_206F_206C_200E_206C_206E_206E_200B_202E_200D_202A_206D_206D_202A_206D_202D_202A_206E_202D_202E_200F_200F_206D_206E_202E_202B_202A_200C_200F_200C_202D_206A_206B_202E_206A_206F_200E_202C_206A_202E = Mathf.MoveTowards(_202B_200B_206F_206C_200E_206C_206E_206E_200B_202E_200D_202A_206D_206D_202A_206D_202D_202A_206E_202D_202E_200F_200F_206D_206E_202E_202B_202A_200C_200F_200C_202D_206A_206B_202E_206A_206F_200E_202C_206A_202E, Mathf.Sign(num22), (autoCenterRate + movementRate) * _202C_202A_202D_202D_200B_206A_206B_200C_200D_206F_200E_206D_202A_200B_202A_202B_206A_206F_202A_206F_206C_200E_206F_202A_206E_206F_202C_206C_206A_206C_200B_206F_200F_202A_202B_206B_206A_206E_202C_202A_202E());
				num2 = 2003998740;
				continue;
			case 21u:
				array3[3] = (int)(num7 * 10000f);
				num2 = -1549360192;
				continue;
			case 43u:
			{
				int num60;
				int num61;
				if (_200E_202C_206C_206E_202D_200F_202A_202A_206F_202A_202D_200F_206C_202E_200B_200D_206B_202B_200E_206B_200C_200E_206E_206A_200D_200D_202D_202B_202C_200D_200F_200C_202B_206B_206E_200F_202D_200B_202A_206B_202E)
				{
					num60 = 2102054979;
					num61 = num60;
				}
				else
				{
					num60 = 1913660553;
					num61 = num60;
				}
				num2 = num60 ^ ((int)num4 * -1579258315);
				continue;
			}
			case 7u:
			{
				int num46;
				int num47;
				if (num7 > 0.1f)
				{
					num46 = 806530733;
					num47 = num46;
				}
				else
				{
					num46 = -900760871;
					num47 = num46;
				}
				num2 = num46 ^ (int)(num4 * 1053903728);
				continue;
			}
			case 40u:
				array3 = base.vehicle.data.Get(0);
				num2 = (int)(num4 * 1164696384) ^ -291175037;
				continue;
			case 5u:
				num10 = 0f;
				num2 = ((int)num4 * -1923607497) ^ 0x4DA0544A;
				continue;
			case 35u:
				num2 = ((int)num4 * -1262609457) ^ -1614698700;
				continue;
			case 94u:
				num25 = Mathf.Clamp01(Mathf.Max(GetAxis(handbrakeAxis), externalHandbrake));
				goto IL_0735;
			case 96u:
				array3[0] = (int)(num22 * 10000f);
				num2 = (int)(num4 * 1972529192) ^ -1108767342;
				continue;
			case 42u:
			{
				int num36;
				int num37;
				if (_200B_200E_206B_200D_200D_202B_200E_200F_206B_206F_202B_200E_202E_206C_206C_202B_200F_202C_200B_200D_202B_200C_206D_202C_206C_200E_200D_200C_202E_206E_206B_202B_206E_200C_206C_200D_202B_200E_202E_206D_202E >= 0)
				{
					num36 = 360118407;
					num37 = num36;
				}
				else
				{
					num36 = 422823004;
					num37 = num36;
				}
				num2 = num36 ^ (int)(num4 * 527742481);
				continue;
			}
			case 72u:
				array3[2] = (int)(num11 * 10000f);
				num2 = ((int)num4 * -973107601) ^ 0x1ADF9244;
				continue;
			case 6u:
				num33 = Mathf.Clamp01(Mathf.Max(GetAxis(clutchAxis), externalClutch));
				num2 = -1966283700;
				continue;
			case 9u:
				if (disableHandbrakeInput)
				{
					num25 = 0f;
					goto IL_0735;
				}
				num2 = -1513857015;
				continue;
			case 26u:
			{
				int num20;
				int num21;
				if (array2[3] != 0)
				{
					num20 = 264696001;
					num21 = num20;
				}
				else
				{
					num20 = -5961920;
					num21 = num20;
				}
				num2 = num20 ^ (int)(num4 * 297778777);
				continue;
			}
			case 99u:
				array3[5] = -1;
				num2 = (int)(num4 * 1261225261) ^ -873280697;
				continue;
			case 36u:
			{
				int num8;
				int num9;
				if (!applyClutchOnHandbrake)
				{
					num8 = 659281982;
					num9 = num8;
				}
				else
				{
					num8 = -1512023299;
					num9 = num8;
				}
				num2 = num8 ^ ((int)num4 * -1489173927);
				continue;
			}
			case 50u:
				goto IL_083f;
			case 22u:
				num7 = 0f;
				num2 = ((int)num4 * -207850123) ^ -347486042;
				continue;
			case 59u:
				goto IL_0872;
			case 45u:
			{
				int num72;
				int num73;
				if (!disableClutchInput)
				{
					num72 = -1928788529;
					num73 = num72;
				}
				else
				{
					num72 = -1596545300;
					num73 = num72;
				}
				num2 = num72 ^ (int)(num4 * 1725575418);
				continue;
			}
			case 95u:
			{
				int num67;
				int num68;
				if (num10 > 0.1f)
				{
					num67 = 1728990789;
					num68 = num67;
				}
				else
				{
					num67 = -437205808;
					num68 = num67;
				}
				num2 = num67 ^ (int)(num4 * 58933966);
				continue;
			}
			case 64u:
				goto IL_08d5;
			case 66u:
				array3[4] = (int)(num33 * 10000f);
				num2 = ((int)num4 * -1148397075) ^ 0x664AB448;
				continue;
			case 39u:
				array3[5] = -1;
				array3[6] = 2;
				num2 = (int)(num4 * 805165132) ^ -166849006;
				continue;
			case 57u:
				num11 = num10;
				num2 = -1025989280;
				continue;
			case 76u:
				array3[1] = (int)(num10 * 10000f);
				num2 = ((int)num4 * -414011352) ^ -1974352009;
				continue;
			case 33u:
			{
				float num66 = num10;
				num10 = num11;
				num11 = num66;
				num2 = (int)((num4 * 2130184092) ^ 0x6E4754B1);
				continue;
			}
			case 30u:
			{
				int num64;
				int num65;
				if (num7 > 0.1f)
				{
					num64 = -1955979352;
					num65 = num64;
				}
				else
				{
					num64 = 1411957304;
					num65 = num64;
				}
				num2 = num64 ^ ((int)num4 * -849072723);
				continue;
			}
			case 63u:
				num10 = 0f;
				num11 = 0f;
				num2 = (int)((num4 * 2013847888) ^ 0x7852EF1);
				continue;
			case 19u:
				array2[3] = 2;
				num2 = ((int)num4 * -1418989477) ^ -1783233613;
				continue;
			case 29u:
				_200B_200E_206B_200D_200D_202B_200E_200F_206B_206F_202B_200E_202E_206C_206C_202B_200F_202C_200B_200D_202B_200C_206D_202C_206C_200E_200D_200C_202E_206E_206B_202B_206E_200C_206C_200D_202B_200E_202E_206D_202E = 1;
				num2 = -1271504155;
				continue;
			case 8u:
				array = base.vehicle.data.Get(1);
				array2 = base.vehicle.data.Get(2);
				num22 = 0f;
				num2 = ((int)num4 * -624340615) ^ 0xD3F7496;
				continue;
			case 77u:
			{
				int num62;
				int num63;
				if (!flag)
				{
					num62 = 1442631865;
					num63 = num62;
				}
				else
				{
					num62 = -1182131507;
					num63 = num62;
				}
				num2 = num62 ^ (int)(num4 * 1419066691);
				continue;
			}
			case 38u:
			{
				int num54;
				int num55;
				if (throttleAndBrakeMode != ThrottleAndBrakeMode.AutoForwardAndReverse)
				{
					num54 = 822460304;
					num55 = num54;
				}
				else
				{
					num54 = 1880593697;
					num55 = num54;
				}
				num2 = num54 ^ ((int)num4 * -761119910);
				continue;
			}
			case 82u:
			{
				speed = base.vehicle.speed;
				int num48;
				int num49;
				if (!(speed <= maxStoppedSpeed))
				{
					num48 = -1514977036;
					num49 = num48;
				}
				else
				{
					num48 = -1403333485;
					num49 = num48;
				}
				num2 = num48 ^ ((int)num4 * -516914008);
				continue;
			}
			case 46u:
				num22 = Mathf.Clamp(GetAxis(steerAxis) + externalSteer, -1f, 1f);
				num2 = -1071006507;
				continue;
			case 61u:
				_200B_200E_206B_200D_200D_202B_200E_200F_206B_206F_202B_200E_202E_206C_206C_202B_200F_202C_200B_200D_202B_200C_206D_202C_206C_200E_200D_200C_202E_206E_206B_202B_206E_200C_206C_200D_202B_200E_202E_206D_202E = 0;
				num2 = ((int)num4 * -1116486301) ^ -1401500558;
				continue;
			case 85u:
				num2 = ((int)num4 * -308557144) ^ 0x7FB713A5;
				continue;
			case 17u:
				num22 = _202B_200B_206F_206C_200E_206C_206E_206E_200B_202E_200D_202A_206D_206D_202A_206D_202D_202A_206E_202D_202E_200F_200F_206D_206E_202E_202B_202A_200C_200F_200C_202D_206A_206B_202E_206A_206F_200E_202C_206A_202E;
				num2 = -1071006507;
				continue;
			case 11u:
			{
				int num44;
				int num45;
				if (array[13] == 2)
				{
					num44 = -176309724;
					num45 = num44;
				}
				else
				{
					num44 = -1500079127;
					num45 = num44;
				}
				num2 = num44 ^ ((int)num4 * -829779076);
				continue;
			}
			case 4u:
			{
				int num42;
				int num43;
				if (_200B_200E_206B_200D_200D_202B_200E_200F_206B_206F_202B_200E_202E_206C_206C_202B_200F_202C_200B_200D_202B_200C_206D_202C_206C_200E_200D_200C_202E_206E_206B_202B_206E_200C_206C_200D_202B_200E_202E_206D_202E != 0)
				{
					num42 = -1763321897;
					num43 = num42;
				}
				else
				{
					num42 = 1429169176;
					num43 = num42;
				}
				num2 = num42 ^ (int)(num4 * 1536808392);
				continue;
			}
			case 84u:
				goto IL_0b48;
			case 86u:
				goto IL_0b6b;
			case 52u:
				goto IL_0b87;
			case 88u:
			{
				int num40;
				int num41;
				if (!brakeOnThrottleBackwards)
				{
					num40 = 1976044932;
					num41 = num40;
				}
				else
				{
					num40 = 444280506;
					num41 = num40;
				}
				num2 = num40 ^ (int)(num4 * 1406762248);
				continue;
			}
			case 0u:
				num2 = (int)(num4 * 1326013738) ^ -1779196937;
				continue;
			case 97u:
				num11 = 1f;
				num2 = ((int)num4 * -1852011869) ^ -946767260;
				continue;
			case 89u:
				array3[5] = 1;
				num2 = (int)((num4 * 762430257) ^ 0x2A731C1D);
				continue;
			case 60u:
			{
				int num34;
				int num35;
				if (num30 < 0)
				{
					num34 = 741162809;
					num35 = num34;
				}
				else
				{
					num34 = 1476488105;
					num35 = num34;
				}
				num2 = num34 ^ ((int)num4 * -2134867812);
				continue;
			}
			case 62u:
				_202B_200B_206F_206C_200E_206C_206E_206E_200B_202E_200D_202A_206D_206D_202A_206D_202D_202A_206E_202D_202E_200F_200F_206D_206E_202E_202B_202A_200C_200F_200C_202D_206A_206B_202E_206A_206F_200E_202C_206A_202E = Mathf.MoveTowards(_202B_200B_206F_206C_200E_206C_206E_206E_200B_202E_200D_202A_206D_206D_202A_206D_202D_202A_206E_202D_202E_200F_200F_206D_206E_202E_202B_202A_200C_200F_200C_202D_206A_206B_202E_206A_206F_200E_202C_206A_202E, 0f, autoCenterRate * _202C_202A_202D_202D_200B_206A_206B_200C_200D_206F_200E_206D_202A_200B_202A_202B_206A_206F_202A_206F_206C_200E_206F_202A_206E_206F_202C_206C_206A_206C_200B_206F_200F_202A_202B_206B_206A_206E_202C_202A_202E());
				num2 = ((int)num4 * -1847139578) ^ 0x52371F0;
				continue;
			case 92u:
				_202C_206C_200F_206B_206C_202E_206F_200E_202C_200B_200D_206A_202B_206E_206C_202A_202C_206F_202A_202A_200F_206D_206C_200E_206A_206F_202E_202D_206E_202B_200D_202A_200B_206D_202B_202C_206D_206D_202B_202A_202E = false;
				num2 = (int)((num4 * 1090745423) ^ 0x2ECCA15B);
				continue;
			case 31u:
				num2 = (int)((num4 * 552000636) ^ 0x7622561);
				continue;
			case 67u:
			{
				int num28;
				int num29;
				if (array[12] >= 0)
				{
					num28 = 2087072544;
					num29 = num28;
				}
				else
				{
					num28 = 1723130694;
					num29 = num28;
				}
				num2 = num28 ^ (int)(num4 * 1342317929);
				continue;
			}
			case 80u:
				num2 = ((int)num4 * -702899308) ^ 0x1197C4F4;
				continue;
			case 81u:
				goto IL_0cc5;
			case 12u:
				num2 = ((int)num4 * -1994071198) ^ 0x7955DC15;
				continue;
			case 56u:
			{
				num7 = 1f;
				int num23;
				int num24;
				if (!_202C_206C_200F_206B_206C_202E_206F_200E_202C_200B_200D_206A_202B_206E_206C_202A_202C_206F_202A_202A_200F_206D_206C_200E_206A_206F_202E_202D_206E_202B_200D_202A_200B_206D_202B_202C_206D_206D_202B_202A_202E)
				{
					num23 = 2009736559;
					num24 = num23;
				}
				else
				{
					num23 = 930071140;
					num24 = num23;
				}
				num2 = num23 ^ (int)(num4 * 174590602);
				continue;
			}
			case 27u:
			{
				int num18;
				int num19;
				if (_202B_206C_200E_202C_202E_200B_206F_200C_202C_206E_202A_206D_206C_202A_202C_206A_202A_206C_206A_206E_206C_200F_206E_200C_200F_200B_202C_206B_200D_200D_206E_202D_202E_200F_206A_202C_200C_206F_202B_200E_202E)
				{
					num18 = 1870805991;
					num19 = num18;
				}
				else
				{
					num18 = 1458052427;
					num19 = num18;
				}
				num2 = num18 ^ (int)(num4 * 1040102358);
				continue;
			}
			case 1u:
				_202B_206C_200E_202C_202E_200B_206F_200C_202C_206E_202A_206D_206C_202A_202C_206A_202A_206C_206A_206E_206C_200F_206E_200C_200F_200B_202C_206B_200D_200D_206E_202D_202E_200F_206A_202C_200C_206F_202B_200E_202E = !_202B_206C_200E_202C_202E_200B_206F_200C_202C_206E_202A_206D_206C_202A_202C_206A_202A_206C_206A_206E_206C_200F_206E_200C_200F_200B_202C_206B_200D_200D_206E_202D_202E_200F_206A_202C_200C_206F_202B_200E_202E;
				num2 = ((int)num4 * -2089623010) ^ 0x28888938;
				continue;
			case 16u:
			{
				int num12;
				int num13;
				if (array[14] != 0)
				{
					num12 = -1802081515;
					num13 = num12;
				}
				else
				{
					num12 = 1563882514;
					num13 = num12;
				}
				num2 = num12 ^ (int)(num4 * 1101952954);
				continue;
			}
			case 18u:
				num2 = ((int)num4 * -1205522374) ^ 0x1B6E9CB9;
				continue;
			case 71u:
				_200B_200E_206B_200D_200D_202B_200E_200F_206B_206F_202B_200E_202E_206C_206C_202B_200F_202C_200B_200D_202B_200C_206D_202C_206C_200E_200D_200C_202E_206E_206B_202B_206E_200C_206C_200D_202B_200E_202E_206D_202E = -1;
				num2 = (int)((num4 * 848510500) ^ 0x217E92D2);
				continue;
			case 83u:
				_202C_206C_200F_206B_206C_202E_206F_200E_202C_200B_200D_206A_202B_206E_206C_202A_202C_206F_202A_202A_200F_206D_206C_200E_206A_206F_202E_202D_206E_202B_200D_202A_200B_206D_202B_202C_206D_206D_202B_202A_202E = true;
				num2 = ((int)num4 * -1665942720) ^ 0x12E90477;
				continue;
			case 3u:
			{
				int num5;
				int num6;
				if (_202B_206C_200E_202C_202E_200B_206F_200C_202C_206E_202A_206D_206C_202A_202C_206A_202A_206C_206A_206E_206C_200F_206E_200C_200F_200B_202C_206B_200D_200D_206E_202D_202E_200F_206A_202C_200C_206F_202B_200E_202E)
				{
					num5 = -813440622;
					num6 = num5;
				}
				else
				{
					num5 = -1325109950;
					num6 = num5;
				}
				num2 = num5 ^ ((int)num4 * -165552866);
				continue;
			}
			case 87u:
				return;
				IL_0735:
				num7 = num25;
				num2 = -353182661;
				continue;
			}
			break;
			IL_0cc5:
			int num76;
			if (_200B_200E_206B_200D_200D_202B_200E_200F_206B_206F_202B_200E_202E_206C_206C_202B_200F_202C_200B_200D_202B_200C_206D_202C_206C_200E_200D_200C_202E_206E_206B_202B_206E_200C_206C_200D_202B_200E_202E_206D_202E != 0)
			{
				num2 = -1949888083;
				num76 = num2;
			}
			else
			{
				num2 = -1901978119;
				num76 = num2;
			}
			continue;
			IL_02ab:
			int num77;
			if (Mathf.Sign(_202B_200B_206F_206C_200E_206C_206E_206E_200B_202E_200D_202A_206D_206D_202A_206D_202D_202A_206E_202D_202E_200F_200F_206D_206E_202E_202B_202A_200C_200F_200C_202D_206A_206B_202E_206A_206F_200E_202C_206A_202E) != Mathf.Sign(num22))
			{
				num2 = 1445620068;
				num77 = num2;
			}
			else
			{
				num2 = 1448843888;
				num77 = num2;
			}
			continue;
			IL_083f:
			int num78;
			if (num30 >= 0)
			{
				num2 = -1131495073;
				num78 = num2;
			}
			else
			{
				num2 = -1886726905;
				num78 = num2;
			}
			continue;
			IL_0b87:
			int num79;
			if (num10 > num11)
			{
				num2 = 697736072;
				num79 = num2;
			}
			else
			{
				num2 = -1949888083;
				num79 = num2;
			}
			continue;
			IL_03cc:
			int num80;
			if (speed >= 0f - maxStoppedSpeed)
			{
				num2 = -805686229;
				num80 = num2;
			}
			else
			{
				num2 = 307721030;
				num80 = num2;
			}
			continue;
			IL_0309:
			throttleAndBrakeMode = this.throttleAndBrakeMode;
			int num81;
			if (throttleAndBrakeMode != 0)
			{
				num2 = -713584539;
				num81 = num2;
			}
			else
			{
				num2 = 141414068;
				num81 = num2;
			}
			continue;
			IL_0b6b:
			int num82;
			if (_202C_206C_200F_206B_206C_202E_206F_200E_202C_200B_200D_206A_202B_206E_206C_202A_202C_206F_202A_202A_200F_206D_206C_200E_206A_206F_202E_202D_206E_202B_200D_202A_200B_206D_202B_202C_206D_206D_202B_202A_202E)
			{
				num2 = -2105004794;
				num82 = num2;
			}
			else
			{
				num2 = -1219288913;
				num82 = num2;
			}
			continue;
			IL_0521:
			int num83;
			if (unlockDrivelineOnHandbrake)
			{
				num2 = 2147169426;
				num83 = num2;
			}
			else
			{
				num2 = 159686281;
				num83 = num2;
			}
			continue;
			IL_023a:
			int num84;
			if (disableThrottleInput)
			{
				num2 = -667749097;
				num84 = num2;
			}
			else
			{
				num2 = 1134648987;
				num84 = num2;
			}
			continue;
			IL_0b48:
			int num85;
			if (MathUtility.FastAbs(speed) >= minStoppedSpeed)
			{
				num2 = 1840027877;
				num85 = num2;
			}
			else
			{
				num2 = 1961300620;
				num85 = num2;
			}
			continue;
			IL_0399:
			int num86;
			if (disableSteerInput)
			{
				num2 = 2099613426;
				num86 = num2;
			}
			else
			{
				num2 = -1630371781;
				num86 = num2;
			}
			continue;
			IL_04c1:
			int num87;
			if (brakeOnThrottleBackwards)
			{
				num2 = 145672596;
				num87 = num2;
			}
			else
			{
				num2 = -1949888083;
				num87 = num2;
			}
			continue;
			IL_08d5:
			int num88;
			if (num30 > 0)
			{
				num2 = -1555256791;
				num88 = num2;
			}
			else
			{
				num2 = -1949888083;
				num88 = num2;
			}
			continue;
			IL_021e:
			int num89;
			if (disableBrakeInput)
			{
				num2 = 1680744656;
				num89 = num2;
			}
			else
			{
				num2 = -1888603797;
				num89 = num2;
			}
		}
		goto IL_000f;
		IL_087f:
		flag = (byte)num != 0;
		num2 = 1168294943;
		goto IL_0014;
	}

	public override void UpdateVehicle()
	{
		//IL_050c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0562: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		int[] array = base.vehicle.data.Get(0);
		int num = array[9];
		while (true)
		{
			int num2 = 94657458;
			while (true)
			{
				int num3 = num2;
				uint num4;
				switch ((num4 = (uint)(~(~(num3 - ~(~-3115927 + (1565101590 - -363894370)))) * 685695853)) % 52)
				{
				case 5u:
					break;
				default:
					return;
				case 48u:
				{
					int num18;
					if (_202A_206B_200B_206D_206D_202E_200D_202E_202A_206F_202B_200B_202E_206A_202E_202C_202A_206F_202B_200D_202C_206E_200D_206E_206B_206F_202B_202D_206A_206B_202A_200F_202A_206D_206A_202D_200F_206F_206F_206F_202E((KeyCode)52))
					{
						num2 = -155536382;
						num18 = num2;
					}
					else
					{
						num2 = 620163057;
						num18 = num2;
					}
					continue;
				}
				case 33u:
				{
					int num8;
					int num9;
					if (!GetButtonDown(gearShiftButton))
					{
						num8 = 1355062793;
						num9 = num8;
					}
					else
					{
						num8 = -502247880;
						num9 = num8;
					}
					num2 = num8 ^ (int)(num4 * 161663786);
					continue;
				}
				case 13u:
					array[9] = 0;
					num2 = (int)((num4 * 1369513526) ^ 0x358241B6);
					continue;
				case 12u:
				{
					int num5;
					int num6;
					if (num == 1)
					{
						num5 = -1931678482;
						num6 = num5;
					}
					else
					{
						num5 = 715574976;
						num6 = num5;
					}
					num2 = num5 ^ (int)(num4 * 2035389612);
					continue;
				}
				case 50u:
				{
					int num17;
					if (_202A_206B_200B_206D_206D_202E_200D_202E_202A_206F_202B_200B_202E_206A_202E_202C_202A_206F_202B_200D_202C_206E_200D_206E_206B_206F_202B_202D_206A_206B_202A_200F_202A_206D_206A_202D_200F_206F_206F_206F_202E((KeyCode)267))
					{
						num2 = 1516586837;
						num17 = num2;
					}
					else
					{
						num2 = 658402033;
						num17 = num2;
					}
					continue;
				}
				case 46u:
				{
					int num32;
					if (_202A_206B_200B_206D_206D_202E_200D_202E_202A_206F_202B_200B_202E_206A_202E_202C_202A_206F_202B_200D_202C_206E_200D_206E_206B_206F_202B_202D_206A_206B_202A_200F_202A_206D_206A_202D_200F_206F_206F_206F_202E(neutralGear))
					{
						num2 = -1401164349;
						num32 = num2;
					}
					else
					{
						num2 = -507023026;
						num32 = num2;
					}
					continue;
				}
				case 45u:
					_202C_206D_206A_202A_200E_202C_200E_206D_200E_206C_206B_202E_202D_206D_200F_206F_206D_206B_206F_206C_206C_200D_206A_200F_206C_206F_200F_200B_200E_200E_206B_206E_202C_200B_206E_202D_200B_202D_202B_202E_202E = externalIgnition;
					num2 = (int)(num4 * 2122916864) ^ -2108836405;
					continue;
				case 19u:
					num2 = ((int)num4 * -355191099) ^ -348692693;
					continue;
				case 35u:
					array[6] = 4;
					num2 = -695882657;
					continue;
				case 3u:
					if (!_202D_200D_200C_206B_202A_200D_206D_206A_206C_200C_206B_206E_202B_206A_202C_202B_200F_206E_202A_200D_206F_200E_202B_200E_206C_202E_206A_202B_200B_206A_206E_206D_206B_206F_200D_200D_206E_202D_206F_206C_202E((KeyCode)305))
					{
						num2 = 518160473;
						continue;
					}
					goto case 8u;
				case 38u:
				{
					int num12;
					if (num == 0)
					{
						num2 = 249483758;
						num12 = num2;
					}
					else
					{
						num2 = -289651632;
						num12 = num2;
					}
					continue;
				}
				case 42u:
					array[5] = 6;
					num2 = (int)((num4 * 1973637077) ^ 0x56CB9265);
					continue;
				case 47u:
				{
					int num34;
					if (!_202A_206B_200B_206D_206D_202E_200D_202E_202A_206F_202B_200B_202E_206A_202E_202C_202A_206F_202B_200D_202C_206E_200D_206E_206B_206F_202B_202D_206A_206B_202A_200F_202A_206D_206A_202D_200F_206F_206F_206F_202E((KeyCode)56))
					{
						num2 = 436628867;
						num34 = num2;
					}
					else
					{
						num2 = -899411289;
						num34 = num2;
					}
					continue;
				}
				case 29u:
					array[9] = 1;
					num2 = ((int)num4 * -657897631) ^ -801398711;
					continue;
				case 20u:
					array[5] = 5;
					num2 = (int)(num4 * 883263646) ^ -1931766306;
					continue;
				case 16u:
				{
					int num30;
					if (_202A_206B_200B_206D_206D_202E_200D_202E_202A_206F_202B_200B_202E_206A_202E_202C_202A_206F_202B_200D_202C_206E_200D_206E_206B_206F_202B_202D_206A_206B_202A_200F_202A_206D_206A_202D_200F_206F_206F_206F_202E((KeyCode)53))
					{
						num2 = -1085401159;
						num30 = num2;
					}
					else
					{
						num2 = -316007058;
						num30 = num2;
					}
					continue;
				}
				case 40u:
				{
					int num25;
					int num26;
					if (array[6] != 3)
					{
						num25 = -1360271166;
						num26 = num25;
					}
					else
					{
						num25 = -35234632;
						num26 = num25;
					}
					num2 = num25 ^ ((int)num4 * -856184862);
					continue;
				}
				case 11u:
					array[9] = (int)(externalIgnition - 1);
					num2 = ((int)num4 * -1192641011) ^ -1554849219;
					continue;
				case 27u:
				{
					int num23;
					if (externalIgnition != _202C_206D_206A_202A_200E_202C_200E_206D_200E_206C_206B_202E_202D_206D_200F_206F_206D_206B_206F_206C_206C_200D_206A_200F_206C_206F_200F_200B_200E_200E_206B_206E_202C_200B_206E_202D_200B_202D_202B_202E_202E)
					{
						num2 = 1649321820;
						num23 = num2;
					}
					else
					{
						num2 = -526126645;
						num23 = num2;
					}
					continue;
				}
				case 39u:
					array[5] = 7;
					num2 = (int)((num4 * 252175916) ^ 0x37A4D4D4);
					continue;
				case 36u:
					array[5] = 3;
					num2 = ((int)num4 * -337754324) ^ -1729290167;
					continue;
				case 2u:
				{
					int num19;
					if (_202A_206B_200B_206D_206D_202E_200D_202E_202A_206F_202B_200B_202E_206A_202E_202C_202A_206F_202B_200D_202C_206E_200D_206E_206B_206F_202B_202D_206A_206B_202A_200F_202A_206D_206A_202D_200F_206F_206F_206F_202E((KeyCode)50))
					{
						num2 = 1921558124;
						num19 = num2;
					}
					else
					{
						num2 = 723218492;
						num19 = num2;
					}
					continue;
				}
				case 23u:
					array[5] = 2;
					num2 = ((int)num4 * -898674535) ^ -819010565;
					continue;
				case 0u:
					array[6] += (int)GetAxis(gearModeSelectButton);
					num2 = ((int)num4 * -822598035) ^ -1927473148;
					continue;
				case 26u:
				{
					int num13;
					if (_202A_206B_200B_206D_206D_202E_200D_202E_202A_206F_202B_200B_202E_206A_202E_202C_202A_206F_202B_200D_202C_206E_200D_206E_206B_206F_202B_202D_206A_206B_202A_200F_202A_206D_206A_202D_200F_206F_206F_206F_202E((KeyCode)55))
					{
						num2 = 1060810956;
						num13 = num2;
					}
					else
					{
						num2 = -490711040;
						num13 = num2;
					}
					continue;
				}
				case 15u:
					array[8]++;
					num2 = (int)((num4 * 1197820624) ^ 0x73B933CB);
					continue;
				case 49u:
				{
					int num35;
					if (!_202A_206B_200B_206D_206D_202E_200D_202E_202A_206F_202B_200B_202E_206A_202E_202C_202A_206F_202B_200D_202C_206E_200D_206E_206B_206F_202B_202D_206A_206B_202A_200F_202A_206D_206A_202D_200F_206F_206F_206F_202E((KeyCode)268))
					{
						num2 = 508544763;
						num35 = num2;
					}
					else
					{
						num2 = 930403724;
						num35 = num2;
					}
					continue;
				}
				case 8u:
					array[9] = -1;
					num2 = -289651632;
					continue;
				case 37u:
					array[7] += (int)GetAxis(gearShiftButton);
					num2 = ((int)num4 * -1082871185) ^ -1519867248;
					continue;
				case 14u:
					array[6] = 3;
					num2 = (int)((num4 * 1718832371) ^ 0x1BA39090);
					continue;
				case 43u:
				{
					int num33;
					if (!keyboardNumbersSelectGears)
					{
						num2 = 436628867;
						num33 = num2;
					}
					else
					{
						num2 = 965927153;
						num33 = num2;
					}
					continue;
				}
				case 34u:
					array[5] = 0;
					num2 = (int)(num4 * 332998597) ^ -179313391;
					continue;
				case 31u:
					array[5] = 1;
					num2 = (int)(num4 * 1462142864) ^ -1761513763;
					continue;
				case 41u:
					array[5] = -1;
					num2 = (int)((num4 * 1964301842) ^ 0x1F1713EA);
					continue;
				case 10u:
				{
					_200E_202C_206C_206E_202D_200F_202A_202A_206F_202A_202D_200F_206C_202E_200B_200D_206B_202B_200E_206B_200C_200E_206E_206A_200D_200D_202D_202B_202C_200D_200F_200C_202B_206B_206E_200F_202D_200B_202A_206B_202E |= GetButtonDown(handbrakeAxis);
					int num31;
					if (disableGearShiftInputs)
					{
						num2 = 459875152;
						num31 = num2;
					}
					else
					{
						num2 = 1792753938;
						num31 = num2;
					}
					continue;
				}
				case 6u:
				{
					int num29;
					if (!GetButtonDown(gearModeSelectButton))
					{
						num2 = 459875152;
						num29 = num2;
					}
					else
					{
						num2 = -351647195;
						num29 = num2;
					}
					continue;
				}
				case 9u:
				{
					int num27;
					int num28;
					if (_202A_206B_200B_206D_206D_202E_200D_202E_202A_206F_202B_200B_202E_206A_202E_202C_202A_206F_202B_200D_202C_206E_200D_206E_206B_206F_202B_202D_206A_206B_202A_200F_202A_206D_206A_202D_200F_206F_206F_206F_202E(ignitionKey))
					{
						num27 = -2045221676;
						num28 = num27;
					}
					else
					{
						num27 = 37174430;
						num28 = num27;
					}
					num2 = num27 ^ (int)(num4 * 1025681741);
					continue;
				}
				case 22u:
					array[5] = 8;
					num2 = ((int)num4 * -1136414665) ^ -1463351407;
					continue;
				case 30u:
					array[9] = 0;
					num2 = ((int)num4 * -906983250) ^ 0x75494258;
					continue;
				case 25u:
				{
					int num24;
					if (_202A_206B_200B_206D_206D_202E_200D_202E_202A_206F_202B_200B_202E_206A_202E_202C_202A_206F_202B_200D_202C_206E_200D_206E_206B_206F_202B_202D_206A_206B_202A_200F_202A_206D_206A_202D_200F_206F_206F_206F_202E(reverseGear))
					{
						num2 = 86603522;
						num24 = num2;
					}
					else
					{
						num2 = -1627987578;
						num24 = num2;
					}
					continue;
				}
				case 21u:
				{
					int num21;
					int num22;
					if (array[6] != 2)
					{
						num21 = -1004766350;
						num22 = num21;
					}
					else
					{
						num21 = 751592973;
						num22 = num21;
					}
					num2 = num21 ^ (int)(num4 * 846227353);
					continue;
				}
				case 18u:
				{
					int num20;
					if (!_206E_202C_206B_206C_206D_206A_206F_206A_202B_206D_200C_206D_200F_206A_206C_206C_206B_206C_202E_200C_206D_200E_206A_202B_200D_200D_200B_202D_206D_206C_206B_206A_202A_202B_206C_200D_202C_202B_200E_202B_202E(ignitionKey))
					{
						num2 = -289651632;
						num20 = num2;
					}
					else
					{
						num2 = 1519535629;
						num20 = num2;
					}
					continue;
				}
				case 7u:
					array[6] = 2;
					num2 = ((int)num4 * -1540853495) ^ 0x450E581D;
					continue;
				case 32u:
					array[8]--;
					num2 = (int)(num4 * 1679144652) ^ -1598156031;
					continue;
				case 4u:
				{
					int num15;
					int num16;
					if (_202A_206B_200B_206D_206D_202E_200D_202E_202A_206F_202B_200B_202E_206A_202E_202C_202A_206F_202B_200D_202C_206E_200D_206E_206B_206F_202B_202D_206A_206B_202A_200F_202A_206D_206A_202D_200F_206F_206F_206F_202E((KeyCode)49))
					{
						num15 = -283244364;
						num16 = num15;
					}
					else
					{
						num15 = -1467977889;
						num16 = num15;
					}
					num2 = num15 ^ ((int)num4 * -1561668481);
					continue;
				}
				case 51u:
				{
					int num14;
					if (!_202A_206B_200B_206D_206D_202E_200D_202E_202A_206F_202B_200B_202E_206A_202E_202C_202A_206F_202B_200D_202C_206E_200D_206E_206B_206F_202B_202D_206A_206B_202A_200F_202A_206D_206A_202D_200F_206F_206F_206F_202E((KeyCode)51))
					{
						num2 = 1002476537;
						num14 = num2;
					}
					else
					{
						num2 = 1767268293;
						num14 = num2;
					}
					continue;
				}
				case 28u:
				{
					int num10;
					int num11;
					if (num != -1)
					{
						num10 = -1209201909;
						num11 = num10;
					}
					else
					{
						num10 = 1987399855;
						num11 = num10;
					}
					num2 = num10 ^ ((int)num4 * -1375667548);
					continue;
				}
				case 1u:
					array[5] = 4;
					num2 = ((int)num4 * -1930946991) ^ 0x3BA9B0BC;
					continue;
				case 17u:
				{
					int num7;
					if (!_202A_206B_200B_206D_206D_202E_200D_202E_202A_206F_202B_200B_202E_206A_202E_202C_202A_206F_202B_200D_202C_206E_200D_206E_206B_206F_202B_202D_206A_206B_202A_200F_202A_206D_206A_202D_200F_206F_206F_206F_202E((KeyCode)54))
					{
						num2 = 1266873291;
						num7 = num2;
					}
					else
					{
						num2 = -2121490433;
						num7 = num2;
					}
					continue;
				}
				case 44u:
					if (!_202D_200D_200C_206B_202A_200D_206D_206A_206C_200C_206B_206E_202B_206A_202C_202B_200F_206E_202A_200D_206F_200E_202B_200E_206C_202E_206A_202B_200B_206A_206E_206D_206B_206F_200D_200D_206E_202D_206F_206C_202E((KeyCode)306))
					{
						num2 = (int)(num4 * 1980229857) ^ -693689016;
						continue;
					}
					goto case 8u;
				case 24u:
					return;
				}
				break;
			}
		}
	}

	public static float GetAxis(string axisName)
	{
		if (!_200C_206E_206A_200E_202B_200B_200C_202D_206B_200C_202C_206A_206E_206E_200E_200D_202C_206E_200F_200E_202E_206E_206F_206E_202B_202D_200E_206C_202C_206A_202E_202A_200B_206E_206A_202A_200C_202D_206B_200C_202E(axisName))
		{
			while (true)
			{
				int num = 1174371268;
				uint num2;
				switch ((num2 = (uint)((~(-num) - --1482560620) ^ -1889322428)) % 3)
				{
				case 0u:
					continue;
				case 2u:
					return _206A_200F_206D_200B_206B_206E_200E_206A_200F_206F_200B_202B_200B_206A_200F_200D_206F_206B_200C_206D_206D_200E_202D_206D_202C_202E_206C_206B_202C_200F_200C_206D_206D_200D_200F_202C_200F_200F_202B_202C_202E(axisName);
				}
				break;
			}
		}
		return 0f;
	}

	public static float GetAxisRaw(string axisName)
	{
		if (!_200C_206E_206A_200E_202B_200B_200C_202D_206B_200C_202C_206A_206E_206E_200E_200D_202C_206E_200F_200E_202E_206E_206F_206E_202B_202D_200E_206C_202C_206A_202E_202A_200B_206E_206A_202A_200C_202D_206B_200C_202E(axisName))
		{
			while (true)
			{
				int num = -1725839400;
				uint num2;
				switch ((num2 = (uint)(~(-759409897 + -1265941791 - (-num - (-64373384 ^ -1867949572))))) % 3)
				{
				case 2u:
					continue;
				case 1u:
					return _202E_202D_200B_206F_200D_200B_206F_206F_200F_206E_202C_206F_202E_200C_200B_206C_202D_200D_200D_202A_202E_200B_206C_200E_202E_206B_200C_206D_202C_206F_206C_202C_206B_200D_202E_202E_206C_200C_200F_206E_202E(axisName);
				}
				break;
			}
		}
		return 0f;
	}

	public static bool GetButtonDown(string buttonName)
	{
		if (!_200C_206E_206A_200E_202B_200B_200C_202D_206B_200C_202C_206A_206E_206E_200E_200D_202C_206E_200F_200E_202E_206E_206F_206E_202B_202D_200E_206C_202C_206A_202E_202A_200B_206E_206A_202A_200C_202D_206B_200C_202E(buttonName))
		{
			while (true)
			{
				int num = -2106704995;
				uint num2;
				switch ((num2 = (uint)((-num * 4455411 - 402057299 * -7284925) ^ -1897091618)) % 3)
				{
				case 2u:
					continue;
				case 1u:
					return _202A_206D_202D_200D_202E_200D_200D_206D_200D_200F_200D_200B_206D_202A_200D_200E_200D_206F_202A_200D_200F_200D_206F_202B_202C_206D_202A_200C_200B_202B_200C_200B_206F_202E_206F_206E_206D_206D_206C_206B_202E(buttonName);
				}
				break;
			}
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VPStandardInput()
	{
	}//IL_0035: Unknown result type (might be due to invalid IL or missing references)
	//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
	//IL_00b8: Unknown result type (might be due to invalid IL or missing references)


	static bool _202D_200D_200C_206B_202A_200D_206D_206A_206C_200C_206B_206E_202B_206A_202C_202B_200F_206E_202A_200D_206F_200E_202B_200E_206C_202E_206A_202B_200B_206A_206E_206D_206B_206F_200D_200D_206E_202D_206F_206C_202E(KeyCode P_0)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return Input.GetKey(P_0);
	}

	static float _202C_202A_202D_202D_200B_206A_206B_200C_200D_206F_200E_206D_202A_200B_202A_202B_206A_206F_202A_206F_206C_200E_206F_202A_206E_206F_202C_206C_206A_206C_200B_206F_200F_202A_202B_206B_206A_206E_202C_202A_202E()
	{
		return Time.deltaTime;
	}

	static bool _202A_206B_200B_206D_206D_202E_200D_202E_202A_206F_202B_200B_202E_206A_202E_202C_202A_206F_202B_200D_202C_206E_200D_206E_206B_206F_202B_202D_206A_206B_202A_200F_202A_206D_206A_202D_200F_206F_206F_206F_202E(KeyCode P_0)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return Input.GetKeyDown(P_0);
	}

	static bool _206E_202C_206B_206C_206D_206A_206F_206A_202B_206D_200C_206D_200F_206A_206C_206C_206B_206C_202E_200C_206D_200E_206A_202B_200D_200D_200B_202D_206D_206C_206B_206A_202A_202B_206C_200D_202C_202B_200E_202B_202E(KeyCode P_0)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return Input.GetKeyUp(P_0);
	}

	static bool _200C_206E_206A_200E_202B_200B_200C_202D_206B_200C_202C_206A_206E_206E_200E_200D_202C_206E_200F_200E_202E_206E_206F_206E_202B_202D_200E_206C_202C_206A_202E_202A_200B_206E_206A_202A_200C_202D_206B_200C_202E(string P_0)
	{
		return string.IsNullOrEmpty(P_0);
	}

	static float _206A_200F_206D_200B_206B_206E_200E_206A_200F_206F_200B_202B_200B_206A_200F_200D_206F_206B_200C_206D_206D_200E_202D_206D_202C_202E_206C_206B_202C_200F_200C_206D_206D_200D_200F_202C_200F_200F_202B_202C_202E(string P_0)
	{
		return Input.GetAxis(P_0);
	}

	static float _202E_202D_200B_206F_200D_200B_206F_206F_200F_206E_202C_206F_202E_200C_200B_206C_202D_200D_200D_202A_202E_200B_206C_200E_202E_206B_200C_206D_202C_206F_206C_202C_206B_200D_202E_202E_206C_200C_200F_206E_202E(string P_0)
	{
		return Input.GetAxisRaw(P_0);
	}

	static bool _202A_206D_202D_200D_202E_200D_200D_206D_200D_200F_200D_200B_206D_202A_200D_200E_200D_206F_202A_200D_200F_200D_206F_202B_202C_206D_202A_200C_200B_202B_200C_200B_206F_202E_206F_206E_206D_206D_206C_206B_202E(string P_0)
	{
		return Input.GetButtonDown(P_0);
	}
}
