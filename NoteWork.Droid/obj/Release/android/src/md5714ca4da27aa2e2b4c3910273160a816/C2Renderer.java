package md5714ca4da27aa2e2b4c3910273160a816;


public class C2Renderer
	extends md5b60ffeb829f638581ab2bb9b1a7f4f3f.TableViewModelRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getView:(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;:GetGetView_ILandroid_view_View_Landroid_view_ViewGroup_Handler\n" +
			"";
		mono.android.Runtime.register ("NoteWork.C2Renderer, NoteWork.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", C2Renderer.class, __md_methods);
	}


	public C2Renderer () throws java.lang.Throwable
	{
		super ();
		if (getClass () == C2Renderer.class)
			mono.android.TypeManager.Activate ("NoteWork.C2Renderer, NoteWork.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public C2Renderer (android.content.Context p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == C2Renderer.class)
			mono.android.TypeManager.Activate ("NoteWork.C2Renderer, NoteWork.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public android.view.View getView (int p0, android.view.View p1, android.view.ViewGroup p2)
	{
		return n_getView (p0, p1, p2);
	}

	private native android.view.View n_getView (int p0, android.view.View p1, android.view.ViewGroup p2);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
