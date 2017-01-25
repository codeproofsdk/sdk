import android.content.ContentProviderClient;
import android.content.ContentResolver;
import android.content.Context;
import android.content.SharedPreferences;
import android.database.ContentObserver;
import android.database.Cursor;
import android.net.Uri;
import android.os.Handler;
import android.os.RemoteException;
import android.util.Log;

public class PolicyManager {

	// provider identifier
	private static final String AUTHORITY = "com.codeproof.mdm.agent.Contentprovider";
	public static final Uri SHARED_POLICY_CONTENT_URI = Uri.parse("content://"
			+ AUTHORITY + "/sharedpolicy");

	private static final String LOG_TAG = "PolicyManager";
	private Context mcontext;


	PolicyManager(Context ctx) {
		mcontext = ctx;
	}

	public String appConfigData() {

		Log.i(LOG_TAG, "Getting App Policy from Codeproof MDM content provider");

		try {

		        //
		        // AppConfig data sent by "Install Application Command"
		        //

			String appConfigData = GetPolicyStringProvider(mcontext, "AppConfig");
	
		} catch (Exception e) {

			Log.e(LOG_TAG,
					"Error reading the applist from Codeproof MDM content provider: " + e);
		}

		return appConfigData;
	}

	
		
	//
	// Content provider helper.
	//
	
	public static String GetPolicyStringProvider(Context context, String Name) {
		
		String Value = null;

		try {

			String[] projection = new String[] { "_id", "name", "value" };

			ContentProviderClient cpclient = context.getContentResolver()
					.acquireContentProviderClient(SHARED_POLICY_CONTENT_URI);

			if (cpclient != null) {
				Cursor c = cpclient.query(SHARED_POLICY_CONTENT_URI,
						projection, "name = '" + Name + "'", null, null);

				if (c.getCount() != 0) {
					c.moveToFirst();

					Value = c.getString(c.getColumnIndex("value"));

				} else {
					Log.e("GetPolicy", "Policy [" + Name + "] not found");

				}

				cpclient.release();
			} else {
				Log.w("PolicyManager",
						"Failed to communicate with Codeproof MDM content provider.");
			}

		} catch (RemoteException e) {
			Log.e("GetPolicy", e.toString());
		}

		return Value;
	}


	//
	// Content modified observer routines
	//

	
	class PolicyContentObserver extends ContentObserver {
		public PolicyContentObserver(Handler h) {
			super(h);
		}

		public void onChange(boolean selfChange) {
			Log.d(LOG_TAG, "PolicyContentObserver.onChange( " + selfChange
					+ ")");

			// notify launcher app
			Log.i("CObzerv", "Remote Observation fired");
			mReceiver.onReceive(mcontext, null);
		}
	}

	void RegisterContentObserver(BroadcastReceiver receiver) {
		mReceiver = receiver;

		ContentResolver cr = mcontext.getContentResolver();
		contentObserver = new PolicyContentObserver(handler);
		cr.registerContentObserver(SHARED_POLICY_CONTENT_URI, true,
				contentObserver);

	}

	void UnRegisterContentObserver() {
		ContentResolver cr = mcontext.getContentResolver();
		if (contentObserver != null) {
			cr.unregisterContentObserver(contentObserver);
			contentObserver = null;
		}
	}

}