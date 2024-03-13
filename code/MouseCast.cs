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
			var mouseray = Scene.Camera.ScreenPixelToRay(Mouse.Position);
			Log.Info(mouseray);
			SceneTraceResult ray = Scene.Trace.Ray(mouseray.Position, mouseray.Forward * int.MaxValue).Run();
			if (ray.Hit)
			{
    			Log.Info(ray.GameObject);
    			Gizmo.Draw.SolidSphere(ray.HitPosition, 30.0f);
			}
			else Log.Warning("didn't hit anything");
			Log.Info("CLIC2");
		}
	}

}