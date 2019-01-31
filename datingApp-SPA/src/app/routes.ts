import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_guard/auth.guard';
import { MembersDetailsComponent } from './members/members-details/members-details.component';
import { MemeberDatailsResolver } from './_resolvers/member-details.reslovers';
import { MembersListResolver } from './_resolvers/member-List.reslovers.';

export const appRoutes: Routes = [
    { path: '', component : HomeComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'members', component : MemberListComponent,
            resolve: {users: MembersListResolver}},
            { path: 'members/:id', component : MembersDetailsComponent,
            resolve: { user: MemeberDatailsResolver}},

            { path: 'list', component : ListsComponent},
            { path: 'messages', component : MessagesComponent }
        ]
    },
     { path: '**' , redirectTo : '' , pathMatch: 'full'}
];
