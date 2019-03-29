
![Microsoft Cloud Workshops](https://github.com/Microsoft/MCW-Template-Cloud-Workshop/raw/master/Media/ms-cloud-workshop.png "Microsoft Cloud Workshops")

<div class="MCWHeader1">
Optimized architecture
</div>

<div class="MCWHeader2">
Whiteboard design session student guide
</div>

<div class="MCWHeader3">
March 2019
</div>

Information in this document, including URL and other Internet Web site references, is subject to change without notice. Unless otherwise noted, the example companies, organizations, products, domain names, e-mail addresses, logos, people, places, and events depicted herein are fictitious, and no association with any real company, organization, product, domain name, e-mail address, logo, person, place or event is intended or should be inferred. Complying with all applicable copyright laws is the responsibility of the user. Without limiting the rights under copyright, no part of this document may be reproduced, stored in or introduced into a retrieval system, or transmitted in any form or by any means (electronic, mechanical, photocopying, recording, or otherwise), or for any purpose, without the express written permission of Microsoft Corporation.

Microsoft may have patents, patent applications, trademarks, copyrights, or other intellectual property rights covering subject matter in this document. Except as expressly provided in any written license agreement from Microsoft, the furnishing of this document does not give you any license to these patents, trademarks, copyrights, or other intellectual property.

The names of manufacturers, products, or URLs are provided for informational purposes only and Microsoft makes no representations and warranties, either expressed, implied, or statutory, regarding these manufacturers or the use of the products with any Microsoft technologies. The inclusion of a manufacturer or product does not imply endorsement of Microsoft of the manufacturer or product. Links may be provided to third party sites. Such sites are not under the control of Microsoft and Microsoft is not responsible for the contents of any linked site or any link contained in a linked site, or any changes or updates to such sites. Microsoft is not responsible for webcasting or any other form of transmission received from any linked site. Microsoft is providing these links to you only as a convenience, and the inclusion of any link does not imply endorsement of Microsoft of the site or the products contained therein.

© 2019 Microsoft Corporation. All rights reserved.

Microsoft and the trademarks listed at https://www.microsoft.com/en-us/legal/intellectualproperty/Trademarks/Usage/General.aspx are trademarks of the Microsoft group of companies. All other trademarks are property of their respective owners.


**Contents**

<!-- TOC -->

- [Optimized architecture whiteboard design session student guide](#optimized-architecture-whiteboard-design-session-student-guide)
    - [Abstract and learning objectives](#abstract-and-learning-objectives)
    - [Step 1: Review the customer case study](#step-1-review-the-customer-case-study)
        - [Customer situation](#customer-situation)
        - [Customer needs](#customer-needs)
        - [Customer objections](#customer-objections)
        - [Infographic for common scenarios](#infographic-for-common-scenarios)
    - [Step 2: Design a proof of concept solution](#step-2-design-a-proof-of-concept-solution)
    - [Step 3: Present the solution](#step-3-present-the-solution)
    - [Wrap-up](#wrap-up)
    - [Additional references](#additional-references)

<!-- /TOC -->

# Optimized architecture whiteboard design session student guide

## Abstract and learning objectives 

In this whiteboard design session, you will review how to size and optimize a migrated workload to Azure Infrastructure as a service (IaaS). From there, you will consider the cost and benefit of optimizing the solution using Azure Platform as a service (PaaS) services and then design and price the optimized solution.

At the end of this whiteboard design session, you will be better able to design and plan for optimizing Azure IaaS and PaaS deployments, price solutions using the Azure calculator, and setup multi-region solutions.

## Step 1: Review the customer case study 

**Outcome**

Analyze your customer's needs.

Timeframe: 15 minutes

Directions: With all participants in the session, the facilitator/SME presents an overview of the customer case study along with technical tips.

1.  Meet your table participants and trainer.

2.  Read all of the directions for steps 1-3 in the student guide.

3.  As a table team, review the following customer case study.

### Customer situation

Contoso Financial Inc. is one of the fastest
growing financial organizations in the United States. With its corporate
headquarters in Chicago, IL, the company has grown to over 1,000
employees. Most employees work from one of the regional offices
strategically located in all the major United States cities. However,
many of the employees work remotely either daily or even after hours.

Contoso has recently completed a migration to shift most its enterprise
data center footprint to the cloud. "The cloud is the future, and as
such, it is essential for us to proactively adopt the cloud before our
competitors to remain innovative and as competitive as possible," says
Emma Lowton, Chief Technology Officer. "Unfortunately, due to our
limited expertise in cloud computing, I have grown concerned that our
Azure spending is much higher than it should be."

The migration process performed by Contoso used the "Lift and shift"
method to move their existing workloads into Microsoft Azure. Their
current Azure usage is dependent on the Infrastructure as a Service
(IaaS) services in addition to the adoption of Azure Active Directory
(AD) and Office 365. So far, they have not used the Platform as a
Service (PaaS) services very much except for Azure Storage and Azure
Service Bus Queue, which replaced MSMQ.

Last year, Contoso completed the acquisition of the European based
Lucerne Ltd. With the acquisition complete, a deadline was set to begin
migrating all Lucerne employees to the Contoso systems within 18 months.
The Chief Executive Office, Jay Calvin's biggest concern with the
existing architecture is, "With concerns about spending too much, I am
very concerned we will not be able to stay competitive, as we onboard
the Lucerne employees over to use Contoso systems."

The company has over 120 workloads migrated to running in Microsoft
Azure. Only a small number of these are considered mission critical.
Ultimately, all the workloads will need to be optimized for reduced
Azure spending without compromising system resiliency and reliability.
The Contoso's IT Operations team has identified a single mission
critical workload that consists of a 3-tier web application with a SQL
Server database. After optimization has been proven with this single
application, plans will be laid to perform similar cost optimizations
across their entire cloud footprint.

It has already been identified that the existing Azure architecture has
been overprovisioned for the workload. The existing architecture within
Azure needs to be modified to match more closely with the workload
demand and use some of the cloud features of Azure that allow for
greater cost savings. In addition to reducing cost, the architecture
also needs to be optimized to be able to handle Contoso's future growth,
even after Lucerne employees have been onboarded.

**Existing architecture**

Percy Bowman is the Director of IT Operations and manages the team
responsible for maintaining the enterprise systems. Percy is concerned
that "the current architecture is much too difficult to maintain over
time with all of the manual operations necessary, especially as the
company continues to grow and expand into Europe." The existing
architecture is made up of multiple virtual machines that need to be
fully managed and maintained by Contoso today. As the company continues
to grow, the system needs to be able to scale more easily, as adding
more VMs over time will eventually lead to prohibitive costs. It is the
primary reason the Contoso enterprise workloads were migrated into the
cloud in the first place.

The system is broken out into three tiers (Front-end Web App, Back-end
Web API, Back-end Processing) and a Microsoft SQL Server database
server. The VM count for the different tiers remains the same as when
the system was hosted on-premises since they performed a straight "Lift
and shift" to move into Azure. The Web App and Web API tiers are made up
of three VMs each. Both the Web App and Web API tiers use an Azure Load
Balancer to distribute traffic across the redundant VMs. The Back-end
Processing tier is made up of two VMs for redundancy, with the
additional benefit of meeting the SLA uptime guarantee.

The Front-end Web App and Back-end Web API tiers are hosted on Windows
Server 2012 R2 using Microsoft Internet Information Services (IIS). The
server-side application code for the Front-end Web App tier is written
in C\# using ASP.NET MVC 5. The application code for the Back-end Web
API tier is written in C\# using ASP.NET Web API and uses Entity
Framework to communicate with the SQL Server database.

The Back-end Processing tier is hosted on Windows Server 2012 R2 with
the application code written as a C\# Console Application. The Back-end
Processing tier receives messages of work to be done from the Back-end
Web API tier using an Azure Service Bus Queue.

The database server is somewhat of a problem area with the current
architecture. During the migration, the production pilot environment was
setup in the Azure West US region. When the final production environment
was built out, it was determined the Azure North Central US region would
be used to better serve users and be located geographically closer to
the corporate headquarters. The database server is running Microsoft SQL
Server 2014, and is hosted on a single VM. So far, the overall necessary
performance demand has been met, but the database server lacks
redundancy. The way it is hosted was only meant to be temporary when
going live into full production. However, in the rush to put out other
production fires at the time of "Go Live", the Production Pilot VM for
the database server stayed in place. According to Percy Bowman,
Directory of IT Operations, "the database server has not failed us yet,
but we know this setup is less than ideal. Although, we do keep backups
in the event of a failure."

![Diagram of the previously described Existing
architecture.](images/Whiteboarddesignsessionstudentguide-Optimizedarchitectureimages/media/image2.png)

**Existing virtual machine utilization**

The Contoso IT Operations team decided to standardize on the "Standard
D3" VM instance size (4 cores, 14GB RAM) for the Front-end and Back-end
tiers using Standard storage. The SQL Server database server VM needs
more resources so it is configured to use the "Standard GS4" VM instance
size (16 cores, 224GB RAM).

Contoso IT Operations team does use some third-party tools to aggregate
server metrics for simplified reporting and monitoring processes.
However, the primary method they used to gather the CPU and RAM
utilization of the specific workload to target was to sign into the
Azure Portal and access Azure's VM monitoring within the Virtual Machine
blade. They gathered both the "CPU percentage" and "Memory usage"
statistics to get average CPU and RAM utilization percentages for the
virtual machines.

The average CPU and RAM usage of the servers during normal business
hours (8AM -- 5PM, Monday through Friday) and the estimated cost per VM
is as follows:

![In this Standard D3 pricing tier, the first row is Front-End Web App
Tier, which offers CPU of 36 percent and RAM of 46 percent, or CPU of 38
percent or RAM of 44 percent. The second row is the Back-End Web App
Tier, which has CPU of 58 percent and RAM of 34 percent, or CPU of 56
percent or RAM of 31 percent. The third row is Back-end processing tier,
which is CPU of 49 percent, and RAM of 25 percent. The bottom row,
Database Server SQL Database: Preium P4, has no CPU or RAM
information.](images/Whiteboarddesignsessionstudentguide-Optimizedarchitectureimages/media/image3.png)

**Database usage analysis**

One of the Database Administrators at Contoso, Naina Dhyani, has
completed some additional performance profiling to help determine how to
optimize the SQL Server VM. Using the production server, Naina captured
performance metrics and used the Azure SQL Database DTU Calculator to
determine the estimated DTU (data through-put unit) requirements of the
SQL Server VM. According to Naina, "It gave me the result that our
database requires about 400 DTUs. I am really not sure what a DTU is,
but I know Azure SQL Databases use that for billing."

### Customer needs 

1.  Design a two-phase approach to the process of migrating Azure
    resources towards the goal of optimized spending.

2.  Fix the SQL Server database hosting to be more robust, reliable, and
    enterprise-grade.

3.  Automatic scaling needs to be implemented to reduce the manual
    process involved.

4.  Identify the appropriate method to use for scaling out the different
    application tiers to meet increases in load.

5.  Identify the appropriate VM sizes for each application tier.

6.  Validate the appropriate Azure Regions are used for hosting and
    create a plan to migrate any necessary resources to a different
    region.

7.  Identify the PaaS services to use, and the App Service Plans, and
    create a migration plan.

8.  Identify a strategy to reduce server maintenance as the system is
    scaled out to meet increased load.

9.  The migration steps should not require any changes to application
    code.

### Customer objections 

1.  Reducing the overall spending on Azure is great, but how will we
    ensure costs remain optimized?

2.  If we drastically change the overall architecture, will we be able
    to migrate it without taking it down for a week?

3.  Our operations team is new to the cloud and Microsoft Azure. While
    we are comfortable using the IaaS services, we are concerned that
    PaaS services will be difficult to monitor and maintain when mixed
    with IaaS services in our overall environment.

4.  We are concerned that the system performance for the European users
    will not be as good as it needs to be. In the past, we have had
    employees work while traveling and the system was slow for them.

5.  The VM sizes currently used appear to be more than we need, but how
    can we determine what the appropriate sizes should be?

6.  We have already purchased SQL Server and other product licenses. I
    am worried the savings from optimizing spending using Azure PaaS
    services will not be significant to be worth it.

### Infographic for common scenarios

Azure virtual network with VMs and load balancers

![Azure infrastructure showing front end subnet and back end
subnet.](images/Whiteboarddesignsessionstudentguide-Optimizedarchitectureimages/media/image4.png)

3-tier Azure Web App architecture with message queue

![The 3-tier Azure Web App architecture with message queue is split into
two sections: Internet (with three user icons), and Azure, with
everything else. The users on the internet side go through a Traffic
Manager to the Azure App Service, with Web App Instances and Autoscale.
This points to the Azure App Service / Back-end Tier, with Web API
Instances and Autoscale. This points to Azure SQL Databases, and also
shares a bi-directional arrow with Message Queue (Storage Queue or
Service Bus Queue.) The Message Queue points to Web Job Instances with
AutoScale, which completes the circle by pointing back to Web API
Instances.](images/Whiteboarddesignsessionstudentguide-Optimizedarchitectureimages/media/image5.png)

## Step 2: Design a proof of concept solution

**Outcome**

Design a solution and prepare to present the solution to the target customer audience in a 15-minute chalk-talk format.

Timeframe: 60 minutes

**Business needs**

Directions:  With all participants at your table, answer the following questions and list the answers on a flip chart:

1.  Who should you present this solution to? Who is your target customer audience? Who are the decision makers?

2.  What customer business needs do you need to address with your solution?

**Design**

Directions: With all participants at your table, respond to the following questions on a flip chart:

**Two-phase solution**

_Phase 1_

Design the changes to the existing solution architecture using IaaS
(Infrastructure as a Service) services to reduce and optimize the cost
of Azure. Included in this phase should be a solution to make the SQL
Server more robust. Identify the steps necessary to modify the
architecture and what needs to be demonstrated to stakeholders.

-   Database server

    -   Which Azure SQL Database hosting solution would you recommend?

    -   What is the recommended Azure Region to use for the SQL
        Database?

    -   What is the recommended Azure SQL Database pricing tier?

-   Cost optimization

    -   What VM scaling solution is recommended?

    -   How do you determine the appropriate VM size for each tier?

    -   What are the recommended VM size and count to use for each
        application tier?

    -   What is the calculated cost and overall savings gained from this
        design?

    -   How do these optimizations reduce the total cost of server
        maintenance and operation?

-   Migration

    -   What order or steps would you recommend taking when changing the
        architecture?

-   Diagram the solution.

_Phase 2_

Outline the changes necessary to transform the Phase 1 architecture
design over to further optimizing Azure spend by using the Azure PaaS
(Platform as a Service) services that fit the solution. Identify the
steps necessary and what needs to be demonstrated to stakeholders to
convince them of the viability of the final solution architecture
design.

-   Cost optimization

    -   What services would you recommend to further optimize the
        solution for lower total cost?

    -   How do you determine the appropriate App Service Plan to use?

    -   What are the recommended App Service Plans to use for each
        application tier?

    -   What is the calculated cost and overall savings gained from this
        design?

    -   How do these optimizations reduce the total cost of server
        maintenance and operation?

-   Scalability

    -   What service should be used to ensure expected application
        performance is maintained when on-boarding Lucerne employees?

-   Migration

    -   What order or steps would you recommend taking when changing the
        architecture?

-   Diagram the solution.

**Prepare**

Directions: With all participants at your table:

1.  Identify any customer needs that are not addressed with the proposed solution.

2.  Identify the benefits of your solution.

3.  Determine how you will respond to the customer's objections.

Prepare a 15-minute chalk-talk style presentation to the customer.

## Step 3: Present the solution

**Outcome**

Present a solution to the target customer audience in a 15-minute chalk-talk format.

Timeframe: 30 minutes

**Presentation**

Directions:

1.  Pair with another table.

2.  One table is the Microsoft team and the other table is the customer.

3.  The Microsoft team presents their proposed solution to the customer.

4.  The customer makes one of the objections from the list of objections.

5.  The Microsoft team responds to the objection.

6.  The customer team gives feedback to the Microsoft team.

7.  Tables switch roles and repeat Steps 2-6.

##  Wrap-up 

Timeframe: 15 minutes

Directions: Tables reconvene with the larger group to hear the facilitator/SME share the preferred solution for the case study.

## Additional references

|    |            |
|----------|:-------------:|
| **Description** | **Links** |
| Windows Virtual Machines documentation | <https://docs.microsoft.com/en-us/azure/virtual-machines/windows/> |
| Azure Reserved VM instances| <https://azure.microsoft.com/en-us/pricing/reserved-vm-instances/> |
| Virtual Machine Pricing | <https://azure.microsoft.com/en-us/pricing/details/virtual-machines/#Windows> |
| Virtual Machine Scale Sets pricing | <https://azure.microsoft.com/en-us/pricing/details/virtual-machine-scale-sets/> |
| Virtual Network overview | <https://docs.microsoft.com/en-us/azure/virtual-network/virtual-networks-overview>|
| Network security group (NSG) overview | <https://docs.microsoft.com/en-us/azure/virtual-network/virtual-networks-nsg>|
| Load Balancer overview | <https://docs.microsoft.com/en-us/azure/load-balancer/load-balancer-overview>|
| Traffic Manager overview| <https://docs.microsoft.com/en-us/azure/traffic-manager/traffic-manager-overview>|
| Web apps overview | <https://docs.microsoft.com/en-us/azure/app-service/overview>|
| Web jobs overview | <https://azure.microsoft.com/en-us/documentation/articles/app-service-webjobs-readme/>|
| Scale a Web App | <https://docs.microsoft.com/en-us/azure/app-service/web-sites-scale> |
| Introduction to Azure SQL database | <https://docs.microsoft.com/en-us/azure/sql-database/sql-database-technical-overview> |
| Azure SQL Database DTU-based service tiers | <https://docs.microsoft.com/en-us/azure/sql-database/sql-database-service-tiers-dtu> |
| Azure SQL Database pricing | <https://azure.microsoft.com/en-us/pricing/details/sql-database/> |
| Azure Channel Pricing calculator | <https://azure.microsoft.com/en-us/pricing/calculator/channel/> |
| Azure Pricing Calculator | <https://azure.microsoft.com/en-us/pricing/calculator>|
| Azure SQL database DTU calculator| <http://dtucalculator.azurewebsites.net/> |
