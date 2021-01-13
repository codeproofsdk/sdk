package com.sequon.vmem.util;




import android.content.BroadcastReceiver;
import android.content.ContentProviderClient;
import android.content.ContentResolver;
import android.content.Context;
import android.database.ContentObserver;
import android.database.Cursor;
import android.net.Uri;
import android.os.Handler;
import android.os.RemoteException;
import android.util.Log;


/**
 * class provided by Codeproof to access Device Policy Manager API
 *
 * 2020
 *
 */
public class PolicyManager {

	// provider identifier
	private static final String AUTHORITY = "com.codeproof.mdm.agent.Contentprovider";
	public static final Uri SHARED_POLICY_CONTENT_URI = Uri.parse("content://" + AUTHORITY + "/sharedpolicy");

	private static final String TAG = "PolicyManager";
	
	private Context mContext;
	private BroadcastReceiver mReceiver;
	private PolicyContentObserver mContentObserver;
	private Handler mHandler;
	
	private static StringBuilder mErrors = new StringBuilder();
	
	PolicyManager(Context ctx) {
		mContext = ctx;
	}

	public String appConfigData() {

		Log.i(TAG, "Getting App Policy from Codeproof MDM content provider");

		String appConfigData = "";
		
		try {

			//
			// AppConfig data sent by "Install Application Command"
			//

			appConfigData = getPolicyStringProvider(mContext, "AppConfig");
	
		} catch (Exception e) {

			Log.e(TAG,
					"Error reading the applist from Codeproof MDM content provider: " + e);
		}

		return appConfigData;
	}
	
	// Content provider helper.
	public static String getPolicyStringProvider(Context context, String Name) {
		
		String PROC = "getPolicyStringProvider";
		String Value = null;

		try {

			String[] projection = new String[] { "_id", "name", "value" };

			ContentProviderClient cpclient = context.getContentResolver().acquireContentProviderClient(SHARED_POLICY_CONTENT_URI);

			if (cpclient != null) {
				Cursor c = cpclient.query(SHARED_POLICY_CONTENT_URI, projection, "name = '" + Name + "'", null, null);

				if (c.getCount() != 0) {
					c.moveToFirst();

					Value = c.getString(c.getColumnIndex("value"));

				} else {
					Log.e(TAG, PROC+" - Policy [" + Name + "] not found");
					mErrors.append(TAG + " - "+PROC+" - Policy [" + Name + "] not found"+"\n");
				}

				cpclient.release();
			} else {
				Log.w(TAG, "Failed to communicate with Codeproof MDM content provider.");
				mErrors.append(TAG + " - "+PROC+" - Failed to communicate with Codeproof MDM content provider."+"\n");
			}

		} catch (RemoteException e) {
			Log.e("GetPolicy", e.toString());
			mErrors.append(TAG + " - "+PROC+" - Exception: " +e.getMessage()+"\n");
		}

		return Value;
	}
	
	/**
	 *
	 * @return
	 */
	public static String getErrors(){
		return mErrors.toString();
	}
	
	
	
	
	// Content modified observer routines
	class PolicyContentObserver extends ContentObserver {
		public PolicyContentObserver(Handler h) {
			super(h);
		}

		public void onChange(boolean selfChange) {
			Log.d(TAG, "PolicyContentObserver.onChange( " + selfChange + ")");

			// notify launcher app
			Log.i("CObzerv", "Remote Observation fired");
			mReceiver.onReceive(mContext, null);
		}
	}

	void RegisterContentObserver(BroadcastReceiver receiver) {
		
		mReceiver = receiver;

		ContentResolver cr = mContext.getContentResolver();
		mContentObserver = new PolicyContentObserver(mHandler);
		cr.registerContentObserver(SHARED_POLICY_CONTENT_URI, true, mContentObserver);

	}

	void UnRegisterContentObserver() {
		ContentResolver cr = mContext.getContentResolver();
		if (mContentObserver != null) {
			cr.unregisterContentObserver(mContentObserver);
			mContentObserver = null;
		}
	}
	
}
