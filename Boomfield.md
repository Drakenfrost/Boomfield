# Boomfield battlefield 2 Mod

## Changes
- None.

### Pending
- Upgraded kits.
- Increased weapon accuracy by reducing bullet deviations.
- Enabled tracer rounds for all weapons.

### Proposed
- Make vehicles stronger.

## Technical Notes

### Weapon Tweaks
The following tweaks should be applied to each weapon. Notes for any special cases should be added directly below this.

#### Weapon Categories
###### Pistol
- USPIS_92FS
###### SMG
- usrif_mp5_a3
###### AR
- USRIF_M4
- usrif_m16a2
- USRIF_M203
- usrif_sa80
###### LMG
- USLMG_M249SAW
###### Sniper
- usrif_m24
###### Shotgun
- usrif_remington11-87

#### Special Cases
- Currently none.

#### Damage
> Generally increase the overall weapon damage.

Set damage to:
- `ObjectTemplate.damage 30` for pistols.
- `ObjectTemplate.damage 40` for pistols.
- `ObjectTemplate.damage 50` for SMGs.
- `ObjectTemplate.damage 60` for ARs and LMGs.
- `ObjectTemplate.damage 100` for semi-auto snipers.
- `ObjectTemplate.damage 120` for bolt-action snipers.

The min damage for all weapons should be `ObjectTemplate.minDamage 10`.

#### Velocity
> Generally decrease the overall projectile velocity.

Set the velocities to:
- `ObjectTemplate.velocity 150` for shotguns.
- `ObjectTemplate.velocity 200` for pistols.
- `ObjectTemplate.velocity 250` for SMGs.
- `ObjectTemplate.velocity 350` for ARs and LMGs.
- `ObjectTemplate.velocity 450` for semi-auto snipers.
- `ObjectTemplate.velocity 500` for bolt-action snipers.
- `ObjectTemplate.velocity 600` for the M95 Barret.

#### Ammo
Set the number of mags to:
- `ObjectTemplate.ammo.nrOfMags 4` for pistols.
- `ObjectTemplate.ammo.nrOfMags 6` for SMGs, ARs, and snipers.
- `ObjectTemplate.ammo.nrOfMags 2` for LMGs and rocket launchers.

#### Zoom
Set the add zoom factor to:
- `ObjectTemplate.zoom.addZoomFactor 0.6` for iron sights.
- `ObjectTemplate.zoom.addZoomFactor 0.3` for normal rifle scopes.
- `ObjectTemplate.zoom.addZoomFactor 0.1` for sniper scopes.
- `ObjectTemplate.zoom.addZoomFactor 0.05` for the M95 Barret.

Always set `ObjectTemplate.zoom.disableMuzzleWhenZoomed 0`.

#### Fire Rate
> Generally decrease the overall fire rate.

Both `ObjectTemplate.fire.roundsPerMinute` and `ObjectTemplate.fire.addFireRate` need to be set based on each specific weapon.

- `ObjectTemplate.fire.roundsPerMinute 600` is a safe middle ground for most full-auto weapons.

Where:
- `ObjectTemplate.fire.addFireRate 0` means semi-auto fire.
- `ObjectTemplate.fire.addFireRate 1` means burst fire.
- `ObjectTemplate.fire.addFireRate 2` means full-auto fire.

#### Deviation
> Generally decrease the overall deviation, thus increasing accuracy.

The base deviation component except for shotguns:
```
rem ---BeginComp:SoldierDeviationComp ---
ObjectTemplate.createComponent SoldierDeviationComp
ObjectTemplate.deviation.setFireDev 0.2 0.1 0.05
ObjectTemplate.deviation.minDev 0.1
ObjectTemplate.deviation.setTurnDev 0 0 0 0
ObjectTemplate.deviation.setSpeedDev 1 0.2 0.2 0.1
ObjectTemplate.deviation.setMiscDev 1 1 0.1
ObjectTemplate.deviation.devModStand 2
ObjectTemplate.deviation.devModCrouch 1.5
ObjectTemplate.deviation.devModLie 1
ObjectTemplate.deviation.devModZoom 0.8
rem ---EndComp ---
```

#### Tracers
The base tracer setup:
```
ObjectTemplate.tracerScaler 30
ObjectTemplate.maxTracerScaler 30
ObjectTemplate.minTracerScaler 1
ObjectTemplate.tracerSizeModifier 5
ObjectTemplate.tracerTemplate p_tracer_g
ObjectTemplate.tracerInterval 1
```

Set `ObjectTemplate.tracerInterval 0` for pistols, shotguns, and snipers.
