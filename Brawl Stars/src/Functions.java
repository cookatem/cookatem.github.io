import java.awt.*;
import java.io.*;
import java.net.*;
public class Functions {
	public static void openUrl(String url) {
		URI uri = null;
		try { uri = new URI(url); } catch (URISyntaxException e) {}
		Desktop desktop = Desktop.isDesktopSupported() ? Desktop.getDesktop() : null;
		if (desktop != null && desktop.isSupported(Desktop.Action.BROWSE)) {
            try {
                desktop.browse(uri);
            } catch (Exception e) {}
        }
	}
}