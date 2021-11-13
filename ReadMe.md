
# SnQMusicStore

# Inhalt
1. [Infrastruktur](#Infrastruktur)
2. [Framework](#Framework)
3. [Kommunikation der Layer](#Kommunikation-der-Layer)
4. [Code-Generierungs-Prozess](#Code-Generierungs-Prozess)

Das Projekt 'SnQMusicStore' ist ein kleiner Framework für die Erstellung von datenzentrierten Anwendungen. Ausgehend von diesem System künnen neue Anwendungen erstellt und erweitert werden. Der Framework unterstützt die Entwicklung einfacher Service-Anwendungen (auch *MicroApps* genannt) als auch die Erstellung von groüen skalierbaren System-Anwendungen. Bei der Herstellung dieser Systeme wird der Entwickler von einem Code-Generator unterstützt. Details zur Arbeitsweise des Generators folgen Sie in den Kapiteln weiter hinten.

## Infrastruktur

Zur Umsetzung des Projektes wird DotNetCore (5.0 und hüher) als Framework, die Programmiersprache CSharp (C#) und die Entwicklungsumgebung Visual Studio 2019 Community verwendet. Alle Komponenten künnen kostenlos aus dem Internet heruntergeladen werden.

In diese Dokumentation werden unterschiedlichste Begriffe verwendet. In der nachfolgenden Tabelle werden die wichtigsten Begriffe zusammengefasst und erlüutert:

|Begriff|Bedeutung|Synonym(e)
|---|---|---
|**Solution**|Ist der Zusammenschluss von verschiedenen Teilprojekten zu einer Gesamtlüsung.|Gesamtlüsung, Lüsung, Projekt
|**Domain Solution**|Hier ist eine Gesamtlüsung gemeint, welches für einen bestimmten Problembereich eine Lüsung darstellt.|Problemlüsung, Projekt
|**Teilprojekt**|Ist die Zusammenstellung von Klassen und/oder Algorithmen, welches eine logische Einheit für die Lüsungen bestimmter Teilprobleme bildet.|Teillüsung, Projekteinheit, Projekt
|**Projekttyp**|Unter Projekttyp wird die physikalische Beschaffenheit eines Projektes bezeichnet. Es gibt zwei grundlegende Typen von Projekten. Zum einen gibt es einen wiederverwendbaren und zum anderen einen ausführbaren Projekttyp. <br>**Als Regel gilt:**<br> Alle Programmteile werden in wiederverwendbare Projekte implementiert. Die ausführbaren Einheiten dienen nur als Startprojekte und leiten die Anfragen an die wiederverwendbaren Projekt-Komponenten weiter.|Bibliothekstyp, Consolentyp
|**Libray**|Kennzeichnet einen wiederverwendbaren Projekttyp.|Bibliothek
|**Console**|Kennzeichnet einen ausführbaren Projekttyp. Dieser Typ startet eine Konsole für die Ausführung.|Konsole
|**Host**|Dieser Typ kennzeichnet ein ausführbares Projekt, welches zum Starten den IIS verwendet oder im Modus 'selfhosting' gestartet werden kann.|Web-Application 
|**Abhüngigkeit**|Die Abhüngikeit beschreibt die Beziehungen von Projekten untereinander. Benütigt ein Projekt Funktionalitüten aus einem andern Projekt, so wird eine Projektreferenz zum anderen Projekt benütigt.|Projektreferenz, Referenz, Dependency, Projektverweis

## Framework
Die Struktur des Frameworks besteht aus unterschiedlichen Teilprojekten und sind in einer Gesamtlüsung (im Kontext von Visual Studio ist das eine Solution) zusammengefasst. Eine Erlüuterung der einzelnen Projekte, deren Typ und die Abhüngigkeit finden sie in der folgenden Tabelle:

|Projekt|Beschreibung|Typ|Abhüngigkeit
|---|---|---|---|
|**CommonBase**|In diesem Projekt werden alle Hilfsfunktionen und allgemeine Erweiterungen zusammengefasst. Diese sind unabhüngig vom Problembereich und künnen auch in andere Domün-Projekte wiederverwendet werden.|Library|keine
|**SnQMusicStore.Contracts**|In diesem Projekt werden alle für das System notwendigen Schnittstellen und Enumerationen implementiert.|Library|CommonBase
|**SnQMusicStore.Logic**|Dieses Projekt beinhaltet den vollstündigen Datenzugriff, die gesamte Geschüftslogik und stellt somit den zentralen Baustein des Systems dar.|Library|CommonBase, SnQMusicStore.Contracts
|**SnQMusicStore.Transfer**|In diesem Projekt werden alle Transferobjekte für den Datenaustausch, zwischen den einzelnen Schichten, verwaltet.|Library|CommonBase, SnQMusicStore.Contracts
|**SnQMusicStore.WebApi**|In diesem Projekt ist die REST-Schnittstelle implementiert. Diese Modul stellt eine API (Aplication Programming Interface) für den Zugriff auf das System über das Netzwerk zur Verfügung.|Host|CommonBase, SnQMusicStore.Transfer, SnQMusicStore.Logic
|**SnQMusicStore.Adapters**|In diesem Projekt ist der Zugriff auf die Logik abstrahiert. Das bedeutet, dass der Zugriff auf die Geschüftslogik direkt oder über die REST-Schnittstelle erfolgen kann. Für dieses Modul ist die Schnittstelle 'IAdapterAccess\<T\>' im Schnittstellen-Projekt implementiert. Nühere Details dazu finden sich im Kapitel 'Kommunikation der Layer'.|Library|CommonBase, SnQMusicStore.Contracts, SnQMusicStore.Logic, SnQMusicStore.Transfer
|**SnQMusicStore.ConApp**|Dieses Projekt dient als Initial-Anwendung zum Erstellen der Datenbank, das Anlegen von Anmeldedaten falls die Authentifizierung aktiv ist und zum Importieren von bestehenden Daten. Nach der Initialisierung wird diese Anwendung kaum verwendet.|Console|SnQMusicStore.Adapters, SnQMusicStore.Contracts , SnQMusicStore.Logic
|**SnQMusicStore.AspMvc**|Diese Projekt beinhaltet die Basisfunktionen für eine AspWeb-Anwendung und kann als Vorlage für die Entwicklung einer einer AspWeb-Anwendung mit dem SnQMusicStore Framework verwendet werden.|Host|CommonBase, SnQMusicStore.Contracts, SnQMusicStore.Adapter
|**SnQMusicStore.XxxYyy**|Es folgen noch weitere Vorlagen von Client-Anwendungen wie Angular, Blazor und mobile Apps. Zum jetzigen Zeitpunkt existiert nur die AspMvc-Anwendung. Die Erstellung und Beschreibung der anderen Client-Anwendungen erfolgt zu einem spüteren Zeitpunk.|Host|CommonBase, SnQMusicStore.Contracts, SnQMusicStore.Adapter.

### Kommunikation der Layer

Die Client-Anwendung interagiert mit dem Backend-System über den Adapters-Layer. Vor dem Zugriff kann der Client den Adapter so konfigurieren, dass der Zugriffpfad auf die Logik direkt oder indirekt über einen REST-Service erfolgt. Der Vorteil eines direkten Zugriffs liegt in der geringeren Datentransformation zwischen der Logik und dem Client. Nachteilig ist allerdings, dass der Client und das Backend-System am gleichen Gerüt ausgeführt werden müssen und die Skalierbarkeit verloren geht. Die nachfolgende Abbildung zeigt den Kommunikations-Pfad zwischen den einzelnen Ebenen.  

![KommunikationsPath](Communication_Path.png)

Die Konfiguration des Zugriffs auf das Backend-System kann über die Factory-Klasse des Layers Adapters gesteuert werden:

```csharp
// Access via the service (indirect).
Adapters.Factory.BaseUri = "https://localhost:5001/api";
Adapters.Factory.Adapter = Adapters.AdapterType.Service;
```

Oder

```csharp
// Access via the controller (direct).
Adapters.Factory.Adapter = Adapters.AdapterType.Controller;
```

Der Zugriff über den Service erfordert natürlich die Angabe der Adresse vom REST-Service. Hingegen ist die Angabe der Web-Adresse für den direkten Zugriff nicht von Bedeutung.

## CSharp-Code-Generator
Bei der Entwicklung eines Systems wird der Entwickler mit einem Code-Generator unterstützt. Der Generator erzeugt für alle Ebenen Standard-Komponenten, welche an die Projektanforderungen angepasst werden künnen. Zu diesem Zweck generiert der Generator die Komponenten als partielle Klassen und für alle Methoden gibt es partielle Methoden, welche vor und nach der Ausführung aufgerufen werden. Nachfolgend ein Auszug aus der Code-Generierung:

```csharp
public void CopyProperties(SnQMusicStore.Contracts.Persistence.MusicStore.IAlbum other)
{
    if (other == null)
    {
        throw new System.ArgumentNullException(nameof(other));
    }
    bool handled = false;
    BeforeCopyProperties(other, ref handled);	// this is a partial methode
    if (handled == false)
    {
        Id = other.Id;
        RowVersion = other.RowVersion;
        ...
    }
    AfterCopyProperties(other);	// this is a partial methode
}
```

Mit diesem Konzept der *partiellen Klassen* und *partiellen Methoden* kann das Standard-Verhalten angepasst bzw. überschrieben werden. Nüheres Details dazu folgen in den Kapiteln 'CSharp-Code-Generierung'. 

Die Projekte für die Code-Generierung sind in der folgenden Tabelle zusammengefasst:  

|Projekt|Beschreibung|Typ|Abhüngigkeit
|---|---|---|---|
|**CSharpCodeGenerator.Logic**|In diesem Projekt ist die Logik für Code-Generierung implementiert. Als Ergebnis der Generierung liefert der Generator den generierten Quellcode in einer Datenklasse (*IEnumerable&lt;IGeneratedItem&gt;*). Somit gibt es auch die Müglichkeit, die Generierung als Service anzubieten. Diese Option wird in einem spüteren Kapitelt behandelt.|Library|CommonBase
|**CSharpCodeGenerator.ConApp**|Dieses Projekt ist die Ausführungseinheit für die Code-Generierung. Die Ergebnisse der Generierung werden in das Dateisystem geschrieben. Falls das Schnittstellen-Projekt aufgrund einer ünderung neu Kompiliert werden muss, wird über ein 'PostBuild-Event' die Ausführung dieses Projekt aktiviert.|Console|CommonBase, CSharpCodeGenerator.Logic

### Code-Generierungs-Prozess
Der Generierungs-Prozess soll mit der nachfolgenden Abbildung veranschaulicht werden.

![Code-Generierung](CodeGeneration.png)

Wird das Schnittstellen Projekt kompiliert, wird anschlieüend automatisch nachdem Kompiliervorgang die Code-Generierung aktiviert. Für die Code-Generierung wird das Schnittstellen Assembly (.Contracts.dll) analysiert und der enstprechende Code generiert. Dies erfolgt über ein 'PostBuildEvent' im Schnittstellen-Projekt. Das Kommando für das 'PostBuildEvent' im Xml-Format lautet 

```csharp
  <Target Name="PostBuild" AfterTargets="PostBuildEvent" Condition="True">
    <Exec Command="ECHO ON&#xD;&#xA;cd ..&#xD;&#xA;cd CSharpCodeGenerator.ConApp&#xD;&#xA;REM dotnet run &quot;-path&quot; $(ProjectDir)$(OutDir)&#xD;&#xA;dotnet build CSharpCodeGenerator.ConApp.csproj&#xD;&#xA;cd $(OutDir)&#xD;&#xA;CSharpCodeGenerator.ConApp.exe" />
  </Target>
``` 

und wird in den Eigenschaften vom Schnittstellen-Projekt '*SnQMusicStore.Contracts*' eingetragen.  
Die Aktivierung der Code-Generierung kann auf 3 verschiedene Varianten erfolgen:
<ol>
  <li>Durch den direkten Start des Projektes 'CSharpCodeGenerator.ConApp'</li>
  <li>Durch die Aktion 'Build Solution' oder 'Run', wenn im Projekt 'CommonBase' eine ünderung vorliegt.</li>
  <li>Durch die Aktion 'Build Solution' oder 'Run', wenn im Projekt 'SnQMusicStore.Contracts' eine ünderung vorliegt.</li>
</ol> 

Je nach der entsprechenden Variante wird die Code-Generierung aktiviert und der generierte Code wird den entsprechenden Projekten zugeordnet. Anschlieüend werden die restlichen Projekte Kompiliert und somit sind alle Teilprojekte aktuell.

## Entwicklerwerkzeuge
Dem Entwickler stehen unterschiedliche Hilfsmittel für die Erstellung von Projekten zur Seite. Die wichtigsten Werkzeuge sind in der nachfolgenden Tabelle zusammengefasst:

|Projekt|Beschreibung|Typ|Abhüngigkeit
|---|---|---|---|
|**SolutionPreprocessorHelper.ConApp**|Mit dieses Anwendung künnen in der gesamten *Solution* Preprocess-Konstante (ACCOUNT_ON oder ACCOUNT_OFF) gesetzt werden.|Console|CommonBase
|**SolutionCopier.ConApp**|Diese Anwendung dient zum Kopieren des *SmatNQuick-Frameworks*. Der Framework dient als Basis für viele zukünftige Projekte und muss dementsprechend kopiert werden. Der *SolutionCopier* kopiert alle Teilprojekte in den Zielordner und führt eine Umbenennung der Komponenten durch.|Console|CommonBase
|**SolutionCodeComparsion.ConApp**|Dieses Projekt dient zum Abgleich aller mit dem Framwork erstellten Domün-Projekten.|Console|CommonBase
|**SolutionDockerBuilder.ConApp**|Dieses Projekt durchsucht die *Solution* nach Dateien mit dem Namen *dockerfile* und führt für jedes *Dockerfile* einen Docker-Build durch.|Console|keine
|**SolutionGeneratedCodeDeleter.ConApp**|Diesem Projekt lüscht alle vom Generator erzeugten Komponenten.|Console|CommonBase

## System-Erstellungs-Prozess

### übersicht  

Wenn nun ein einfacher Service oder eine Anwendung entwickelt werden soll, dann kann der Framework 'SnQMusicStore' als Ausgangsbasis verwendet und weiterentwickelt werden. Dazu empfiehlt sich folgende Vorgangsweise:  

#### Vorbereitungen

- Erstellen eines Ordners (z.B.: QnSDevelop)
- Herunterladen des Repositories 'SnQMusicStore' von GitHub (<https://github.com/leoggehrer/CSSoftwareEngineering-SnQMusicStore> und in den Ordner 'QnSDevelop' speichern.  
**ACHTUNG:** Der Solution-Ordner vom Framework muss *SnQMusicStore* heiüen.

#### Projekterstellung
Die nachfolgenden Abbildung zeigt den Erstellungs-Ablauf für ein Domain-Projekt schematisch dar:  

![Erstellungsprozess](CreateProject.png)

Als Ausgangsbasis wird der Framework 'SnQMusicStore' verwendet. Diese Projekt wird mit Hilfe dem Hilfsprogramm '*SolutionCopier.ConApp*' in ein Verzeichnis nach eigener Wahl kopiert. In diesem Verzeichnis werden alle Projektteile vom Framework kopiert und die Namen der Projekte und Komponenten werden entsprechend angepasst. Alle Projekte mit einem domainspezifischen Namen werden durch den Namen des Verzeichnisses ersetzt.  

Zum Beispiel soll ein Projekt mit dem Namen 'QnSTravelCount' erstellt werden. Im 'SolutionCopier' werden folgende Parameter eingestellt:  

```csharp
SourcePath = @"BasePath\SnQMusicStore";     // Verzeichnis - Framework-SnQMusicStore
TargetPath = @"BasePath\QnSTravelCount";  // Verzeichnis - Domain-Project

var sc = new SolutionCopier();

sc.Copy(sourcePath, targetPath);
```

**Hinweis:** Beide Projekte müssen im gleichen Verzeichnis gespeichert (*BasePath*) sein.  

Nach dem Ausführen vom SolutionCopier (*sc.Copy(sourcePath, targetPath)*) befindet sich folgende Verzeichnisstruktur in **...\QnSTravelCount**:  

- CommonBase
- CSharpCodeGenerator.ConApp
- QnSTravelCount.Contracts
- QnSTravelCount.Logic
- QnSTravelCount.Transfer
- QnSTravelCount.WebApi
- QnSTravelCount.Adapters
- QnSTravelCount.ConApp
- QnSTravelCount.AspMvc
- ...

Im Projekt 'SnQMusicStore' sind alle Code-Teile, welche als Basis-Code in andere Projekte verwendet werden künnen, mit einem Label '//@CodeCopy' markiert. Dieser Label wird im Zielprojekt mit dem Label '//@CodeCopy' ersetzt. Das hat den Vorteil, dass ünderungen im Framework auf die bereits bestehenden Projekte übertragen werden künnen (nühere Informationen dazu gibt es spüter).  

### Anpassen des Projektes  

Nach dem Erzeugen des 'Projektes' werden die Schnittstellen im Schnittstellen-Projekt definiert und das Projekt erstellt. Beim Erstellen wird zuerst das Schnittstellen-Projekt Kompiliert und nach deren übersetzung wird der CSharpCodeGenerator.ConApp ausgeführt. Diese Ausführung wird mit dem Build-Event im Schnittstellen Projekt aktiviert. Das Ausführen des Code-Generator kann natürlich auch jederzeit manuell erfolgen.  

Beim Ausführen des Generators werden die Komponenten der Reihe nach generiert:  

- Generierung der Entities im Logik-Projekt  
- Generierung des DataContext im Logik-Projekt  
- Generierung der Kontroller-Klassen im Logik-Projekt
- Generierung der Fabrik-Klasse im Logik-Projekt
- Generierung der Transfer-Klassen im Tranfer-Projekt
- Generierung der Kontroller-Klassen im WebApi-Projekt
- Generierung der Fabrik-Klasse im Adapter-Projekt

Die generierten Komponenten werden in den Dateien mit dem Namen '_GeneratedCode.cs' in den jeweiligen Modulen abgelegt. Diese Dateien werden nach jeder ünderung neu erzeugt und dürfen auf keinem Fall vom Entwickler angepassten Code enthalten. Detailes zum Anpassen des Domain-Projektes finden sich im Beispiel [QnSTravelCount](https://github.com/leoggehrer/QnSTravelCount).  

### Synchronisieren vom Framework (SnQMusicStore) mit den Domain-Projekten  

In der Software-Entwicklung gibt es immer wieder Verbesserungen und Erweiterungen. Das betrifft den Framework 'SnQMusicStore' genauso wie alle anderen Projekte. Nun stellt sich die Frage: Wie künnen Verbesserungen und/oder Erweiterungen vom Framework auf die Domain-Projekte übertragen werden? Im Framework sind die Quellcode-Dateien mit Labels (@CodeCopy) gekennzeichnet. Beim Kopieren werden diese Labels durch den Label (@CodeCopy) ersetzt. Mit dem Hilfsprogramm BaseCodeCopier werden die Dateien mit dem Label '@CodeCopy' und '@CodeCopy' abgeglichen. In der folgenden Skizze ist dieser Prozess dargestellt:

![Synchron-Prozess](SyncProjects.png)

Die Einstellungen für den Abgleichprozess müssen wie folgt definiert werden:

```csharp
// Quell-Project: SnQMusicStore
SourcePath = @"BasePath\SnQMusicStore";     // Verzeichnis - Framework-SnQMusicStore
var targetPaths = new string[]
{
    // Target-Projects
	@"BasePath\DomainProject1",
	@"BasePath\DomainProject2",
	@"BasePath\DomainProject3",
};
Paths.Add(SourcePath, targetPaths);
```

Des Programm 'SolutionCodeComparsion.ConApp' muss manuell gestartet werden damit der Abgleich-Prozess aktiviert wird. Sollen Dateien vom Abgleich-Prozess ausgenommen werden, dann künnen die Labels (@CodeCopy) in den einzelnen Dateien im Ziel-Projekt entfernt werden.  
## Code-Generierungs-Prozess  

In der obigen Abbildung ist der Code-Generierungs-Prozess schematisch dargestellt. Der Code-Generator bekommt als Eingabe-Information die 'Domain-Projekt.Contracts.dll' und der Generator generiert aufgrund dieser Informationen die einzelnen Komponenten und letgt diese in den enstprechenden Teil-Projekten ab. Dieser Prozess wird automatisch ausgeführt, wenn eine ünderung im Schnittstellen-Projekt durchgeführt wurde. Der Prozess kann natürlich auch manuell akiviert werden. In beiden Füllen wird der gesamte generierte Code wieder vollstündig erzeugt.  

Wie bereits erwühnt, werden bei der Code-Generierung viele Komponenten vom System erzeugt. Diese Komponenten werden in den Dateien mit dem Label '@GeneratedCode' abgelegt und künnen vom Programmierer abgeündert werden. Allerdings sollten keine ünderungen in diesen Dateien vorgenommen werden, da der Code-Generator diese wieder neu erzeugt und dadurch die ünderungen verloren gehen. Ist dies doch erwünscht, dann sollte der Labe '@GeneratedCode' entfernt werden. Dann wird diese Datei vom Generator vom Generierungs-Prozess ausgeschlossen. Eine besser Variante ist jedoch die Erstellung einer partiellen Klasse für die Anpassung der Komponente.

### Entities  

Die Entities werden vom Generator vollstündig erzeugt und Ergünzungen vom Programmierer sind nicht erforderlich. Der Generator erzeugt die Entities in folgenden Schritten:

1.Erzeugen der Definition - Entitüt

```csharp
partial class Travel : QnSTravelCount.Contracts.Persistence.App.ITravel
{
```

2.Erzeugen des **Klassen-Konstruktors** und die 'partial'-Methoden

```csharp
	static Travel()
	{
		ClassConstructing();
		ClassConstructed();
	}
	static partial void ClassConstructing();
	static partial void ClassConstructed();
```

3.Erzeugen des **Konstruktors** und die 'partial'-Methoden

```csharp
	public Travel()
	{
		Constructing();
		Constructed();
	}
	partial void Constructing();
	partial void Constructed();
```

4.Erzeugen der **Eigenschaften**

```csharp
	public System.String Designation
	{
		get
		{
			OnDesignationReading();
			return _designation;
		}
		set
		{
			bool handled = false;
			OnDesignationChanging(ref handled, ref _designation);
			if (handled == false)
			{
				this._designation = value;
			}
			OnDesignationChanged();
		}
	}
	private System.String _designation;
	partial void OnDesignationReading();
	partial void OnDesignationChanging(ref bool handled, ref System.String _designation);
	partial void OnDesignationChanged();
```

5.Erzeugen der **CopyProperties**-Methode

```csharp
	public void CopyProperties(QnSTravelCount.Contracts.Persistence.App.ITravel other)
	{
		if (other == null)
		{
			throw new System.ArgumentNullException(nameof(other));
		}
		bool handled = false;
		BeforeCopyProperties(other, ref handled);
		if (handled == false)
		{
			Id = other.Id;
			Timestamp = other.Timestamp;
			Designation = other.Designation;
		}
		AfterCopyProperties(other);
	}
	partial void BeforeCopyProperties(QnSTravelCount.Contracts.Persistence.App.ITravel other, ref bool handled);
	partial void AfterCopyProperties(QnSTravelCount.Contracts.Persistence.App.ITravel other);
```

6.Erzeugen der **Equals**-Methode

```csharp
	public override bool Equals(object obj)
	{
		if (!(obj is QnSTravelCount.Contracts.Persistence.App.ITravel instance))
		{
			return false;
		}
		return base.Equals(instance) && Equals(instance);
	}
	protected bool Equals(QnSTravelCount.Contracts.Persistence.App.ITravel other)
	{
		if (other == null)
		{
			return false;
		}
		return Id == other.Id && IsEqualsWith(Timestamp, other.Timestamp) && IsEqualsWith(Designation, other.Designation);
	}
```

7.Erzeugen der **GetHashCode()**-Methode
```csharp
	public override int GetHashCode()
	{
		return HashCode.Combine(Id, Timestamp, Designation);
	}
}
```

8.Erzeugen der Ableitung

```csharp
partial class Travel : IdentityObject
{
}
```

9.Erzeugen der Navigation-Eigenschaften

```csharp
partial class Travel
{
	public System.Collections.Generic.ICollection<QnSTravelCount.Logic.Entities.Persistence.App.Expense> Expenses
	{
		get;
		set;
	}
}
```

**Viel Spaü beim Testen!**
