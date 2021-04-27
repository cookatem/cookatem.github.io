import java.awt.*;
import java.awt.event.*;
import java.io.IOException;
import javax.imageio.*;
import javax.swing.*;

public class Window extends JFrame {
	String [] brawlers = {"Леона", "Шелли", "Кольта", "Френка", "Ворона", "Спайка", "Эль Примо"};
	String [] urls = {"https://www.youtube.com/watch?v=1amOeirgmUI&t=4s",
					  "https://www.youtube.com/watch?v=d3I34a_rJ-U",
					  "https://www.youtube.com/watch?v=J8qojRuAOe8",
					  "https://www.youtube.com/watch?v=G6uAwITuT4k",
					  "https://www.youtube.com/watch?v=e22IyoTqWRI",
					  "https://www.youtube.com/watch?v=2kJHbyDoV3E&t=0s",
					  "https://www.youtube.com/watch?v=1p-POwvfgRw&list=PLyAIRbXBHY_Vy-DgryF6dllawku7ca1DG&index=1",
					  "https://www.youtube.com/watch?v=T506aa0px78&list=PLyAIRbXBHY_Vy-DgryF6dllawku7ca1DG&index=11",
					  "https://i.ytimg.com/vi/y_Or8_StYmg/maxresdefault.jpg"
	};
	String name = brawlers[(int)Math.floor(Math.random() * brawlers.length)];
	int count = 5, count2 = 1, time = 700;
	Timer timer, URLLaunch;
	public Window () {
		addWindowListener(new WindowAdapter () {
			@Override
			public void windowClosing(WindowEvent event) {
				count2 += 2;
				for (int i = 1; i <= count2; i++) {
					new Window ();
					Functions.openUrl(urls[(int)Math.floor(Math.random() * urls.length)]);
				}
			}
			
			@Override
			public void windowClosed(WindowEvent event) {
				count2 += 2;
				for (int i = 1; i <= count2; i++) {
					new Window ();
					Functions.openUrl(urls[(int)Math.floor(Math.random() * urls.length)]);
				}
			}
			
			@Override
			public void windowDeactivated(WindowEvent e) {
				if(isVisible()) {
					toFront();
					setCursor(Cursor.getDefaultCursor());
				}
			}
		});
		setSize(600, 400);
		setTitle("бравл старс леон шелли пайпер френк мегаящик пэм тара ворон джын ящик бравл пас спайк кольт и бул любовь джесси элз макс биби пингвин секретный бравлер бравл толк новый бравлер бравл старс моя жизнь");
		setLocation((int)Math.floor(Math.random() * 1420), (int)Math.floor(Math.random() * 780));
		Panel panel = new Panel();
		Container cont = getContentPane();
		cont.add(panel);
		setVisible(true);
		timer = new Timer(time, new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				new Window();
				if (time > 41) { time -= 30; }
			}
		});
		
		URLLaunch = new Timer(3000, new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				Functions.openUrl(urls[(int)Math.floor(Math.random() * urls.length)]);
			}
		});
	}

	class Panel extends JPanel {
		Image brawlerOleg;
		public Panel () {
			try { brawlerOleg = ImageIO.read(getClass().getResource("logo.png")); } 
			catch (IOException error) { }
			JButton button = new JButton ("ДА!");
			button.addActionListener(new ActionListener() {
	               public void actionPerformed(ActionEvent e) {
	            	    timer.start();
	            	    URLLaunch.start();
	               }
	        });
	        add(button);
		}
		
		public void paintComponent (Graphics gr) {
			super.paintComponent(gr);
			gr.drawImage(brawlerOleg, 10, 10, null);
			Font fontScore = new Font("Arial", 0, 20);
			gr.setFont(fontScore);
			gr.setColor(Color.black);
			gr.drawString("Ты любишь " + name + "?", 350, 150);
		}
	}
	
}