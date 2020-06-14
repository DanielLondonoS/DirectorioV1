import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { DetailPostPage } from './detail-post.page';

describe('DetailPostPage', () => {
  let component: DetailPostPage;
  let fixture: ComponentFixture<DetailPostPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailPostPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(DetailPostPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
