using UnityEngine;
using System.Collections;

public class GizmoDrawer : MonoBehaviour
{
	/**
	 * @param angle in radias
	 */
	public static Vector3 rotatedPointFromPoint( Vector3 c, float angle, float radius, float offset )
	{
		float x = c.x + Mathf.Cos( angle + offset ) * radius;
		float y = c.y - Mathf.Sin( angle + offset ) * radius;
		float z = c.z;
        Vector3 p = new Vector3( x, y, z );
        return p;
	}
	
	/**
	 * @param angle in radias
	 */
    public static Vector3 rotatedPointFromCenter( Transform t, float angle, float radius )
    {
        float halfPI = Mathf.PI / 2.0f;
		return rotatedPointFromPoint( t.position, angle, radius, t.eulerAngles.z * Mathf.Deg2Rad - halfPI );
    }

	/**
	 * @param angle in radias
     */
    public static void drawArc( Transform t, float radius, int segments, float degree, bool isClosed = false )
    {
        float increment = degree / (float)segments;
        bool firstOne = true;
        Vector3 firstPoint = new Vector3();
		Vector3 lastPoint = new Vector3();
        float halfDegree = degree * 0.5f;
        for (float theta = 0.0f; theta < (degree); theta += increment)
        {
            Vector3 currentPoint = GizmoDrawer.rotatedPointFromCenter( t, theta - halfDegree, radius);
            if (firstOne) {
                firstOne = false;
				firstPoint = currentPoint;
			}
            else
                Gizmos.DrawLine(lastPoint, currentPoint);
            lastPoint = currentPoint;
        }
		
		if ( isClosed ) {
			Gizmos.DrawLine(lastPoint, firstPoint);
		}
    }

    /**
     *
     */
    public static void drawCircle( Transform t, float radius, int segments )
    {
		drawArc( t, radius, segments, 2.0f * Mathf.PI, true );
    }


	/**
	 * @param angle in radias
     */
    public static void drawCircle( Vector3 center, float radius, int segments )
    {
		float degree = 2.0f * Mathf.PI;
        float increment = degree / (float)segments;
        bool firstOne = true;
        Vector3 firstPoint = new Vector3();
		Vector3 lastPoint = new Vector3();
        for (float theta = 0.0f; theta < (degree); theta += increment)
        {
            Vector3 currentPoint = GizmoDrawer.rotatedPointFromPoint( center, theta, radius, 0.0f );
            if (firstOne) {
                firstOne = false;
				firstPoint = currentPoint;
			}
            else
                Gizmos.DrawLine(lastPoint, currentPoint);
            lastPoint = currentPoint;
        }
		
		Gizmos.DrawLine(lastPoint, firstPoint);
    }
	
	/**
     * @param angle in radians
     */
    public static void drawAngleLine( Transform t, float angle, float radius )
    {
        Vector3 origin = t.position;
        Gizmos.DrawLine( origin, GizmoDrawer.rotatedPointFromCenter( t, angle, radius ) );
    }
	
	public static void drawArc3P( Vector3 center, Vector3 A, Vector3 B, int segments )
	{
		float radius = Vector3.Distance( center, A );
		Vector3 v1 = A - center;
		Vector3 v2 = B - center;
		float degree = Vector3.Angle( v1, v2 ) * Mathf.Deg2Rad;
		
		Vector3 w = Vector3.Cross( v1.normalized, Vector3.forward );
		float v2Dot = Vector3.Dot( v2.normalized, w );
		if ( v2Dot > 0.0f )
			degree = 2.0f * Mathf.PI - degree;
		
		float offset = -Vector3.Angle( v1, Vector3.right ) * Mathf.Deg2Rad;
		float dot = Vector3.Dot( v1.normalized, Vector3.up );
		if ( dot < 0.0f )
			offset = -offset;
		
        float increment = degree / (float)segments;
		Vector3 lastPoint = new Vector3();
        bool firstOne = true;
		float theta = 0.0f;
		for ( int i = 0; i <= segments; i++ ) {
        //for (float theta = 0.0f; theta < degree; theta += increment) {
			Vector3 currentPoint = GizmoDrawer.rotatedPointFromPoint( center, -theta, radius, offset );
			if (firstOne) {
				firstOne = false;
			}
			else {
				Gizmos.DrawLine(lastPoint, currentPoint);
			}
 			lastPoint = currentPoint;
			theta += increment;
		}
	}
	
	public static void drawQuad( Vector3 center, float w, float h )
	{
		Vector3 W = new Vector3( w * 0.5f, 0.0f, 0.0f );
		Vector3 H = new Vector3( 0.0f, h * 0.5f, 0.0f );

		Vector3 A = center - W + H;
		Vector3 B = center + W + H;
		Vector3 C = center + W - H;
		Vector3 D = center - W - H;
		
		Gizmos.DrawLine( A, B );
		Gizmos.DrawLine( B, C );
		Gizmos.DrawLine( C, D );
		Gizmos.DrawLine( D, A );
	}
}
