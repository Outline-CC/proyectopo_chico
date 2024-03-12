using System.Diagnostics;
using Sandbox;
using Sandbox.Physics;

public sealed class MouseCast : Component
{
	protected override void OnUpdate()
	{
		if (Input.Pressed("attack1"))
		{
			Log.Info("CLIC");
			Vector3 mousePos = Mouse.Position;
			Log.Info(mousePos);
			Vector3 rayDirection = Transform.Local.PointToWorld(mousePos);
			Log.Info(rayDirection);
			var ray = Scene.Trace.Ray(mousePos, mousePos + rayDirection * 1000.0f).Size(1.0f).UseHitboxes().Run();
			Gizmo.Draw.Arrow(mousePos, mousePos + rayDirection * 1000.0f);
			if (ray.Hit)
			{
				Log.Info(ray);
			} else Log.Warning("didn't hit anything");
		}
	}

}